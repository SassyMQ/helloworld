package astronomer

import (  
    "fmt"
    "time"
)

type Astronomer struct { 
    AstronomerId string
    createdTime time.Time
    DOB string
    Name string
}

func (a Astronomer) ToString() {  
    fmt.Printf("Astronomer: %s", a.Name)
}


