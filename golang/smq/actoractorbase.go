package smq

import (
	"encoding/json"
	"fmt"
	"log"
	"os"
	"os/user"
	"time"

	"github.com/google/uuid"
	"github.com/streadway/amqp"
)

type ActorBase struct {
	actor_name     string
	sender_id      uuid.UUID
	sender_name    string
	connection     *amqp.Connection
	channel        *amqp.Channel
	listener_queue *amqp.Queue
	reply_queue    *amqp.Queue
	handlers       map[string]interface{}
	reply_handlers map[string]interface{}
	queue          string
	exchange       string
	connStr        string
	ActorBaseActions
}

type ActorBaseActions interface {
	Init()
	InitTest()
	CreateListener()
}

func (p *ActorBase) CreatePayload() *Payload {
	payload := new(Payload)
	pid, err := uuid.NewUUID()
	DefaultWithPanic(err, "Failed to create uuid")
	payload.PayloadId = pid.String()
	payload.SenderId = p.sender_id.String()
	payload.SenderName = p.sender_name
	return payload
}

func (p *ActorBase) CloseAll() {
	err := p.channel.Close()
	DefaultWithPanic(err, "Failed to close actorbase channel")
	err = p.connection.Close()
	DefaultWithPanic(err, "Failed to close actorbase connection")
}

func (p *ActorBase) InitBase(actor string, connStr string) {
	p.actor_name = actor
	p.connStr = connStr
	p.queue = actor + ".all"
	p.exchange = actor + "mic"
	senderId, err := uuid.NewUUID()
	DefaultWithPanic(err, "Failed to create sender id")
	p.sender_id = senderId

	hostname, err := os.Hostname()
	Default(err, "Failed to get hostname")

	currentUser, err := user.Current()
	Default(err, "Failed to get current user")

	p.sender_name = fmt.Sprintf("smq://%s:%s@golang", currentUser.Username, hostname)

	err = p.SetConnection(connStr)
	DefaultWithPanic(err, "Failed to initiate actorbase connection")
	err = p.SetChannel()
	DefaultWithPanic(err, "Failed to initiate actorbase channel")
	err = p.SetQos()
	DefaultWithPanic(err, "Issue setting channel Qos")
}

func (p *ActorBase) Init(actor string, connStr string) {
	p.InitBase(actor, connStr)

	err := p.ResetHandlers()
	DefaultWithPanic(err, "Failed to initiate handlers map")
	err = p.CreateListener()
	DefaultWithPanic(err, "Failed to initiate queue listener")
}

func (p *ActorBase) SetConnection(address string) error {
	conn, err := amqp.Dial(address)
	if err == nil {
		p.connection = conn
	}
	return err
}

func (p *ActorBase) SetChannel() error {
	ch, err := p.connection.Channel()
	if err == nil {
		p.channel = ch
	}
	return err
}

func (p *ActorBase) SetQos() error {
	err := p.channel.Qos(
		1,     // Prefetch count
		0,     // Prefetch size
		false, // Global
	)
	return err
}

func (p *ActorBase) CreateListener() error {
	err := p.DeclareListenerQueue()
	if err == nil {
		go p.listenForever()
		q, err := p.channel.QueueDeclare(
			"",    // Name
			true,  // Durable
			false, // Delete when unused
			false, // Exclusive
			false, // No-wait
			nil,   // Arguments
		)
		if err == nil {
			p.reply_queue = &q
			go p.awaitRepliesForever()
		}

	}
	return err
}

func (p *ActorBase) listenForever() {
	msgs, err := p.StartConsumption()
	Default(err, "Failed to register a consumer")

	go func() {
		for d := range msgs {
			log.Printf("%s  received a message: %s", p.queue, d.RoutingKey)
			if value, ok := p.handlers[string(d.RoutingKey)]; ok {
				var payload *Payload
				json.Unmarshal(d.Body, &payload)
				replyPayload := value.(func(*ActorBase, *Payload) *Payload)(p, payload)
				if replyPayload != nil {
					replyPayloadJson, err := json.Marshal(replyPayload)
					DefaultWithPanic(err, "Can't marshal reply payload")
					p.channel.Publish("", d.ReplyTo, false, false,
						amqp.Publishing{
							DeliveryMode: amqp.Persistent,
							ContentType:  "text/plain",
							Body:         []byte(replyPayloadJson),
						})
				}
			} else {
				Default(nil, "Handler not defined")
			}
			d.Ack(false)
		}
	}()

	forever := make(chan bool)
	<-forever
}

func (p *ActorBase) awaitRepliesForever() {
	msgs, err := p.channel.Consume(
		p.reply_queue.Name, // Queue
		"",                 // Consumer
		false,              // Auto-ack
		false,              // Exclusive
		false,              // No-local
		false,              // No-wait
		nil,                // Args
	)
	Default(err, "Failed to start consuming reply queue")

	go func() {
		for d := range msgs {
			var payload *Payload
			err := json.Unmarshal(d.Body, &payload)
			DefaultWithPanic(err, "Can't unmarshal payload to json")
			replyJSON, err := json.Marshal(payload)
			DefaultWithPanic(err, "Could not read reply payload")
			log.Printf("%s received a REPLY message: %s", p.queue, replyJSON)
			if replyHandler, ok := p.reply_handlers[d.CorrelationId]; ok {
				delete(p.reply_handlers, d.CorrelationId)
				replyHandler.(func(*ActorBase, *Payload) *Payload)(p, payload)
			}

			// Wait for messages
			d.Ack(false)
		}
	}()

	forever := make(chan bool)
	<-forever
}

func (p *ActorBase) Publish(exchange string, key string, mandatory bool, immediate bool, publishing amqp.Publishing) error {
	err := p.channel.Publish(
		exchange,  // exchange
		key,       // routing key
		mandatory, // mandatory
		immediate, // immediate
		publishing)
	return err
}

func (p *ActorBase) QueueDeclare(name string, durable bool, should_delete bool, exclusive bool, no_wait bool, args amqp.Table) (amqp.Queue, error) {
	q, err := p.channel.QueueDeclare(
		name,          // Name
		durable,       // Durable
		should_delete, // Delete when unused
		exclusive,     // Exclusive
		no_wait,       // No-wait
		args,          // Arguments
	)
	return q, err
}

func (p *ActorBase) AddHandler(key string, value interface{}) error {
	p.handlers[key] = value
	return nil
}

func (p *ActorBase) RemoveHandler(key string) error {
	delete(p.handlers, key)
	return nil
}

func (p *ActorBase) ResetHandlers() error {
	p.handlers = make(map[string]interface{})
	p.reply_handlers = make(map[string]interface{})
	return nil
}

func (p *ActorBase) SendPayload(routingKey string, payload *Payload, replyHandler interface{}) error {
	payloadId, err := uuid.NewUUID()
	DefaultWithPanic(err, "Failed to create uuid")
	payload.PayloadId = payloadId.String()
	payloadJson, err := json.Marshal(payload)
	DefaultWithPanic(err, "Can't marshal payload as Json")

	err = p.channel.Publish(
		p.exchange, // exchange
		routingKey, // routing key
		false,      // mandatory
		false,      // immediate
		amqp.Publishing{
			DeliveryMode:  amqp.Persistent,
			ContentType:   "text/plain",
			CorrelationId: payload.PayloadId,
			ReplyTo:       p.reply_queue.Name,
			Body:          []byte(payloadJson),
		})

	if replyHandler != nil {
		p.reply_handlers[payload.PayloadId] = replyHandler
		go p.WaitForReply(payload, 10)
	}

	return err
}

func (actor *ActorBase) WaitForReply(payload *Payload, timeout_seconds int) {
	time.Sleep(time.Duration(timeout_seconds) * time.Second)
	if replyPayload, ok := actor.reply_handlers[payload.PayloadId]; ok {
		if replyPayload != nil {
			fmt.Println("TIMED OUT WAITING FOR REPLY: ", payload.PayloadId)
			delete(actor.reply_handlers, payload.PayloadId)
		}
	}
}

func (actor *ActorBase) GetListenQueueSize() int {
	q, err := actor.channel.QueueInspect(actor.queue)
	if err != nil {
		return 0
	} else {
		return q.Messages
	}
}

func (actor *ActorBase) DeclareListenerQueue() error {
	q, err := actor.channel.QueueDeclare(
		actor.queue, // Name
		true,        // Durable
		false,       // Delete when unused
		false,       // Exclusive
		false,       // No-wait
		nil,         // Arguments
	)
	if err != nil {
		return err
	} else {
		actor.listener_queue = &q
		return nil
	}
}

func (actor *ActorBase) StartConsumption() (<-chan amqp.Delivery, error) {
	msgs, err := actor.channel.Consume(
		actor.listener_queue.Name, // Queue
		"",    // Consumer
		false, // Auto-ack
		false, // Exclusive
		false, // No-local
		false, // No-wait
		nil,   // Args
	)
	return msgs, err
}

func (actor *ActorBase) GetQueueName() string {
	return actor.queue
}

func (actor *ActorBase) GetChannel() *amqp.Channel {
	return actor.channel
}

func (actor *ActorBase) GetExchange() string {
	return actor.exchange
}

