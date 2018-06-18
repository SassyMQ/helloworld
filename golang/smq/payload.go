package smq

type Payload struct {
	PayloadId   string
	SenderId    string
	SenderName  string
    Content     string
    ReplyContent    string
    ErrorMessage    string
}
