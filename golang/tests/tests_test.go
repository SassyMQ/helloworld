package tests

import (
	"encoding/json"
	"io/ioutil"
	"testing"
	"time"
)

func TestRouting(t *testing.T) {
	// Where results will be stored
	test_results := make([]ActorResults, 0)

	// Initiate actors
 	// Programmer - 
	programmer := new(TestActor)
	programmer.Init("programmer", "amqp://guest:guest@localhost/SMQ")
 	// World - 
	world := new(TestActor)
	world.Init("world", "amqp://guest:guest@localhost/SMQ")
 	// Universe - 
	universe := new(TestActor)
	universe.Init("universe", "amqp://guest:guest@localhost/SMQ")

	// Create payloads
 	// Programmer - 
	programmer_payload := programmer.CreatePayload()
	programmer_payload.Content = "Programmer"
 	// World - 
	world_payload := world.CreatePayload()
	world_payload.Content = "World"
 	// Universe - 
	universe_payload := universe.CreatePayload()
	universe_payload.Content = "Universe"

	// Send payloads by routing keys
	// Run tests for Programmer:
	programmer.SendPayload("world.general.programmer.hello", programmer_payload)
	programmer.SendPayload("programmer.general.world.whatsup", programmer_payload)
	programmer.SendPayload("world.general.programmer.goodbye", programmer_payload)
	programmer.SendPayload("world.general.programmer.getallgalaxies", programmer_payload)
	programmer.SendPayload("world.general.universe.yoyo", programmer_payload)
    
  
	// Run tests for World:
	world.SendPayload("world.general.programmer.hello", world_payload)
	world.SendPayload("programmer.general.world.whatsup", world_payload)
	world.SendPayload("world.general.programmer.goodbye", world_payload)
	world.SendPayload("world.general.programmer.getallgalaxies", world_payload)
	world.SendPayload("world.general.universe.yoyo", world_payload)
    
  
	// Run tests for Universe:
	universe.SendPayload("world.general.programmer.hello", universe_payload)
	universe.SendPayload("programmer.general.world.whatsup", universe_payload)
	universe.SendPayload("world.general.programmer.goodbye", universe_payload)
	universe.SendPayload("world.general.programmer.getallgalaxies", universe_payload)
	universe.SendPayload("world.general.universe.yoyo", universe_payload)
    
   


	// Consume Queues
  
	go programmer.ListenAndConsume()
	go world.ListenAndConsume()
	go universe.ListenAndConsume()


	// Check Queues' Statuses
	for {
		msgs := 0
    
		msgs = msgs + programmer.GetListenQueueSize()
		msgs = msgs + world.GetListenQueueSize()
		msgs = msgs + universe.GetListenQueueSize()
		if msgs > 0 {
			time.Sleep(50 * time.Millisecond)
		} else {
			break
		}
	}

	// Build report structure
	
	// Accumulate and save test results for Programmer
	actor_results := ActorResults{}
	actor_results.Actor = "Programmer"
	actor_results.Received = programmer.GetFoundRoutingKeys()
	test_results = append(test_results, actor_results)
  
	// Accumulate and save test results for World
	actor_results = ActorResults{}
	actor_results.Actor = "World"
	actor_results.Received = world.GetFoundRoutingKeys()
	test_results = append(test_results, actor_results)
  
	// Accumulate and save test results for Universe
	actor_results = ActorResults{}
	actor_results.Actor = "Universe"
	actor_results.Received = universe.GetFoundRoutingKeys()
	test_results = append(test_results, actor_results)
  

	// Write report
	report_json, err := json.MarshalIndent(test_results, "", "  ")
	DefaultWithPanic(err, "Failed to marshal struct to json")
	err = ioutil.WriteFile("sassymq_report.json", report_json, 0644)
}

