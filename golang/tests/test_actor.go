package tests

import (
	"encoding/json"
	"log"

	"github.com/eejai42/helloworld/golang/smq"
	"github.com/eejai42/sassymq-golang/errors"
	"github.com/google/uuid"
	"github.com/streadway/amqp"
)

type TestActor struct {
	found_routing_keys map[string][]string
	smq.ActorBase
	TestActorActions
}

type TestActorActions interface {
	Init()
	ListenAndConsume()
	GetFoundRoutingKeys()
}

func (ta *TestActor) Init(actorName string, connStr string) {
	ta.ActorBase.InitBase(actorName, connStr)

	err := ta.ResetFoundRoutingKeys()
	errors.DefaultWithPanic(err, "Failed to initiate handlers map")
}

func (ta *TestActor) ResetFoundRoutingKeys() error {
	ta.found_routing_keys = make(map[string][]string)
	return nil
}

func (ta *TestActor) ListenAndConsume() {
	err := ta.ActorBase.DeclareListenerQueue()
	errors.DefaultWithPanic(err, "Failed to declare listener queue")
	msgs, err := ta.ActorBase.StartConsumption()
	errors.DefaultWithPanic(err, "Failed to register a consumer")

	go func() {
		for d := range msgs {
			log.Printf("%s  received a message: %s", ta.ActorBase.GetQueueName(), d.RoutingKey)
			var payload *smq.Payload
			json.Unmarshal(d.Body, &payload)
			ta.found_routing_keys[payload.Content] = append(ta.found_routing_keys[payload.Content], d.RoutingKey)
			d.Ack(false)
		}
	}()

	forever := make(chan bool)
	<-forever
}

func (ta *TestActor) GetFoundRoutingKeys() map[string][]string {
	return ta.found_routing_keys
}

func (ta *TestActor) SendPayload(routingKey string, payload *smq.Payload) error {
	payloadId, err := uuid.NewUUID()
	errors.DefaultWithPanic(err, "Failed to create uuid")
	payload.PayloadId = payloadId.String()
	payloadJson, err := json.Marshal(payload)
	errors.DefaultWithPanic(err, "Can't marshal payload as Json")
	c := ta.GetChannel()
	e := ta.GetExchange()
	err = c.Publish(
		e,          // exchange
		routingKey, // routing key
		false,      // mandatory
		false,      // immediate
		amqp.Publishing{
			DeliveryMode:  amqp.Persistent,
			ContentType:   "text/plain",
			CorrelationId: payload.PayloadId,
			Body:          []byte(payloadJson),
		})

	return err
}
