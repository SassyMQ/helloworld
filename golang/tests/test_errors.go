package tests

import (
	"fmt"
	"log"
)

func DefaultWithPanic(err error, msg string) {
	if err != nil {
		log.Fatalf("%s: %s", msg, err)
		panic(fmt.Sprintf("%s: %s", msg, err))
	}
}

func Default(err error, msg string) {
	if err != nil {
		log.Fatalf("%s: %s", msg, err)
		fmt.Printf("%s: %s", msg, err)
	}
}
