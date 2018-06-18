package galaxy

import (  
    "fmt"
    "time"
)

type Galaxy struct { 
    GalaxyId string
    createdTime time.Time
    FirstSeen int
    Name string
    HaveVisited bool
    Notes string
}

func (g Galaxy) ToString() {  
    fmt.Printf("Galaxy: %s", g.Name)
}


