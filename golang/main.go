package main

import (
	"fmt"

	"github.com/eejai42/helloworld/golang/smq"
)

func main() {

	programmer := new(smq.Programmer)

	programmer.Init("amqp://guest:guest@localhost/SMQ")

	programmer.HelloStr("What's up world?", func(actor *smq.ActorBase, reply *smq.Payload) *smq.Payload {

		fmt.Println("Got a reply from the world on hello")
		return reply
	})

	programmer.GoodbyeStr("I'm out of here", func(actor *smq.ActorBase, reply *smq.Payload) *smq.Payload {

		fmt.Println("Got a reply from the world after goodbye")
		return reply
	})

	programmer.GetAllGalaxies(programmer.CreatePayload(), func(actor *smq.ActorBase, reply *smq.Payload) *smq.Payload {

		fmt.Println("Got a reply from the world after goodbye")

		for index := range reply.Galaxies {
			galaxy := reply.Galaxies[index]
			fmt.Println("GALAXY: ", galaxy.Name)
		}
		return reply
	})

	select {}
}
