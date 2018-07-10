package tests

type ActorResults struct {
	Actor    string              `json:"Actor"`
	Received map[string][]string `json:"Received"`
}