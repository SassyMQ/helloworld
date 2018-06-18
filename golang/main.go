package main

import (
	"fmt"

	"github.com/eejai42/helloworld/golang/smq"
)

func main() {

	programmer := new(smq.Programmer)

	programmer.Init("amqp://guest:guest@localhost/SMQ")

	programmer.HelloStr("What's up world?", func(actor *smq.ActorBase, reply *smq.Payload) *smq.Payload {

		fmt.Println("Got a hello from a programmer")
		return reply
	})

	select {}
}
