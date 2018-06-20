package results

type ActorResults struct {
	Actor    string              `json:"actor"`
	Recieved map[string][]string `json:"recieved"`
}
