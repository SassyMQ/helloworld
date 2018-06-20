package smq

import (
	"fmt"
)

type World struct {
	ActorBase
	WorldActions
}

type WorldActions interface {
	Init()

	WhatsUp()
}

func (p *World) Init(connStr string) {
	p.ActorBase.Init("world", connStr)
}

func (p *World) WhatsUpStr(payloadContent string, replyHandler interface{}) error {
	payload := p.CreatePayload()
	payload.Content = payloadContent
	return p.WhatsUp(payload, replyHandler)
}

func (p *World) WhatsUp(payload *Payload, replyHandler interface{}) error {
	err := p.SendPayload("programmer.general.world.whatsup", payload, replyHandler)
	fmt.Println("Sending payload to: 'programmer.general.world.whatsup' - ", payload.PayloadId)
	return err
}

func (p *World) AddProgrammerHelloHandler(value interface{}) error {
	err := p.AddHandler("world.general.programmer.hello", value)
	return err
}
func (p *World) AddProgrammerGoodbyeHandler(value interface{}) error {
	err := p.AddHandler("world.general.programmer.goodbye", value)
	return err
}
func (p *World) AddProgrammerGetAllGalaxiesHandler(value interface{}) error {
	err := p.AddHandler("world.general.programmer.getallgalaxies", value)
	return err
}
