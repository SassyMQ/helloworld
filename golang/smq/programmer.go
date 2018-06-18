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
    



func (p *Programmer) AddWorldWhatsUpHandler(value interface{}) error {
	err := p.AddHandler("programmer.general.world.whatsup", value)
	return err
}

    