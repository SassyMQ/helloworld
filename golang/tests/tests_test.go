package tests

import (
	"encoding/json"
	"fmt"
	"io/ioutil"
	"testing"
	"time"

	"github.com/eejai42/helloworld/golang/smq"
	"github.com/eejai42/sassymq-golang/errors"
)

func TestRouting(t *testing.T) {
	// Where results will be stored
	test_results := make([]ActorResults, 0)

	// Initiate actors
	programmer := new(smq.Programmer)
	programmer.InitTest("amqp://guest:guest@localhost:5672/local")

	world := new(smq.World)
	world.InitTest("amqp://guest:guest@localhost:5672/local")

	// Create payloads
	programmer_payload := programmer.CreatePayload()
	programmer_payload.Content = "Programmer"

	world_payload := world.CreatePayload()
	world_payload.Content = "World"

	// Send payloads by routing keys
	programmer.SendPayload("world.general.programmer.hello", programmer_payload, nil)
	programmer.SendPayload("programmer.general.world.wassup", programmer_payload, nil)
	programmer.SendPayload("world.general.programmer.goodbye", programmer_payload, nil)
	programmer.SendPayload("world.general.programmer.getallgalaxies", programmer_payload, nil)

	world.SendPayload("world.general.programmer.hello", world_payload, nil)
	world.SendPayload("programmer.general.world.wassup", world_payload, nil)
	world.SendPayload("world.general.programmer.goodbye", world_payload, nil)
	world.SendPayload("world.general.programmer.getallgalaxies", world_payload, nil)

	time.Sleep(3 * time.Second)

	for programmer.GetListenQueueSize()+world.GetListenQueueSize() > 0 {
		count := programmer.GetListenQueueSize() + world.GetListenQueueSize()
		fmt.Println("Messages remaining: ", count)
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
