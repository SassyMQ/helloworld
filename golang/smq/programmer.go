package smq
        
import (
    "fmt"
)

type Programmer struct {
	ActorBase
	ProgrammerActions
}

type ProgrammerActions interface {
	Init()
	
    Hello()
    Goodbye()
    GetAllGalaxies()
}

func (p *Programmer) Init(connStr string) {
	p.ActorBase.Init("programmer", connStr)
}


func (p *Programmer) HelloStr(payloadContent string, replyHandler interface{}) error {
    payload := p.CreatePayload()
    payload.Content = payloadContent
    return p.Hello(payload, replyHandler)
}    

func (p *Programmer) Hello(payload *Payload, replyHandler interface{}) error {
	err := p.SendPayload("world.general.programmer.hello", payload, replyHandler)
    fmt.Println("Sending payload to: 'world.general.programmer.hello' - ", payload.PayloadId)
	return err
}
    
func (p *Programmer) GoodbyeStr(payloadContent string, replyHandler interface{}) error {
    payload := p.CreatePayload()
    payload.Content = payloadContent
    return p.Goodbye(payload, replyHandler)
}    

func (p *Programmer) Goodbye(payload *Payload, replyHandler interface{}) error {
	err := p.SendPayload("world.general.programmer.goodbye", payload, replyHandler)
    fmt.Println("Sending payload to: 'world.general.programmer.goodbye' - ", payload.PayloadId)
	return err
}
    
func (p *Programmer) GetAllGalaxiesStr(payloadContent string, replyHandler interface{}) error {
    payload := p.CreatePayload()
    payload.Content = payloadContent
    return p.GetAllGalaxies(payload, replyHandler)
}    

func (p *Programmer) GetAllGalaxies(payload *Payload, replyHandler interface{}) error {
	err := p.SendPayload("world.general.programmer.getallgalaxies", payload, replyHandler)
    fmt.Println("Sending payload to: 'world.general.programmer.getallgalaxies' - ", payload.PayloadId)
	return err
}
    



func (p *Programmer) AddWorldWhatsUpHandler(value interface{}) error {
	err := p.AddHandler("programmer.general.world.whatsup", value)
	return err
}

    