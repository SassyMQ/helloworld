package tests

import (
	"encoding/json"
	"io/ioutil"
	"testing"
	"time"

	"github.com/eejai42/sassymq-golang/errors"
)

func TestRouting(t *testing.T) {
	// Where results will be stored
	test_results := make([]ActorResults, 0)

	// Initiate actors
	programmer := new(TestActor)
	programmer.Init("programmer", "amqp://guest:guest@localhost:5672/local")

	world := new(TestActor)
	world.Init("world", "amqp://guest:guest@localhost:5672/local")

	// Create payloads
	programmer_payload := programmer.CreatePayload()
	programmer_payload.Content = "Programmer"

	world_payload := world.CreatePayload()
	world_payload.Content = "World"

	// Send payloads by routing keys
	programmer.SendPayload("world.general.programmer.hello", programmer_payload)
	programmer.SendPayload("programmer.general.world.wassup", programmer_payload)
	programmer.SendPayload("world.general.programmer.goodbye", programmer_payload)
	programmer.SendPayload("world.general.programmer.getallgalaxies", programmer_payload)

	world.SendPayload("world.general.programmer.hello", world_payload)
	world.SendPayload("programmer.general.world.wassup", world_payload)
	world.SendPayload("world.general.programmer.goodbye", world_payload)
	world.SendPayload("world.general.programmer.getallgalaxies", world_payload)

	// Consume Queues
	go programmer.ListenAndConsume()
	go world.ListenAndConsume()

	// Check Queues' Statuses
	for {
		msgs := 0
		msgs = msgs + programmer.GetListenQueueSize()
		msgs = msgs + world.GetListenQueueSize()
		if msgs > 0 {
			time.Sleep(50 * time.Millisecond)
		} else {
			break
		}
	}

	// Build report structure
	actor_results := ActorResults{}
	actor_results.Actor = "Programmer"
	actor_results.Recieved = programmer.GetFoundRoutingKeys()
	test_results = append(test_results, actor_results)

	actor_results = ActorResults{}
	actor_results.Actor = "World"
	actor_results.Recieved = world.GetFoundRoutingKeys()
	test_results = append(test_results, actor_results)

	// Write report
	report_json, err := json.MarshalIndent(test_results, "", "  ")
	errors.DefaultWithPanic(err, "Failed to marshal struct to json")
	err = ioutil.WriteFile("sassymq_report.json", report_json, 0644)
}
