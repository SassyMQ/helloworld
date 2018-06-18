package config

import (
	"encoding/json"
	"log"
	"os"
	"strings"

	"github.com/eejai42/sassymq-golang/errors"
)

type Config struct {
	URI string `json: "uri"`
}

var conf *Config

func Init() *Config {
	configPath := GetConfigPackagePath()

	file, err := os.Open(configPath)
	errors.DefaultWithPanic(err, "File <"+configPath+"> was not found. Please make sure you have copied the template file <config.json.template> into a new file <config.json> with appropriate values")

	decoder := json.NewDecoder(file)
	err = decoder.Decode(&conf)
	errors.DefaultWithPanic(err, "Unable to decode json")

	if len(conf.URI) == 0 {
		log.Fatalf("Error: URI cannot be empty string")
		panic("Error: URI cannot be empty string")
	}

	return conf
}

func GetConf() *Config {
	return conf
}

func GetConfigPackagePath() string {
	dir, err := os.Getwd()
	errors.DefaultWithPanic(err, "Failed to get filepath")

	paths := strings.Split(dir, "helloworld")
	return paths[0] + "helloworld/config/config.json"
}
