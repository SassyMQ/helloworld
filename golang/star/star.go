package star

import (  
    "fmt"
    "time"
)

type Star struct { 
    StarId string
    createdTime time.Time
    FoundBy string
    Galaxy string
    Name string
    Notes string
}

func (s Star) ToString() {  
    fmt.Printf("Star: %s", s.Name)
}


