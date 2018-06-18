package smq

import "github.com/eejai42/helloworld/golang/galaxy"

type Payload struct {
	PayloadId    string
	SenderId     string
	SenderName   string
	Content      string
	ReplyContent string
	ErrorMessage string
	Galaxies     []galaxy.Galaxy
}
