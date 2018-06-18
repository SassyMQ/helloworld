package star

import (  
    "fmt"
    "time"
)

type Star struct { 
    StarId string
    createdTime time.Time
    FoundBy string
    NasaID string
    Galaxy string
    Name string
    Notes string
    LightYearsFromEarth int
}

func (s Star) ToString() {  
    fmt.Printf("Star: %s", s.Name)
}


