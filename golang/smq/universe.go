package smq
        
import (
    "fmt"
)

type Universe struct {
	ActorBase
	UniverseActions
}

type UniverseActions interface {
	Init()
	
    YoYo()
}

func (p *Universe) Init(connStr string) {
	p.ActorBase.Init("universe", connStr)
}


func (p *Universe) YoYoStr(payloadContent string, replyHandler interface{}) error {
    payload := p.CreatePayload()
    payload.Content = payloadContent
    return p.YoYo(payload, replyHandler)
}    

func (p *Universe) YoYo(payload *Payload, replyHandler interface{}) error {
	err := p.SendPayload("world.general.universe.yoyo", payload, replyHandler)
    fmt.Println("Sending payload to: 'world.general.universe.yoyo' - ", payload.PayloadId)
	return err
}
    




    