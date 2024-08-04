# MotorregisterAPI

Motorregister API enables callers to programmatically retrieve information stored in the central "Motor Register".
"Motor Registeret" holds information about vehicles registered in Denmark, and this API can be used to 
retrieve data about a vehicle such as: a vehicles specifications, the permits associated with a vehicle, and the inspection
history of a vehicle. So far, all lookups are made using a vehicles registration number, and all requests return a single result - 
all information associated with the given license plate.

Motorregister API uses an indexer to retrieve and parse "Motor Registeret" since it is published as an XML file.
Once a week, the database is synchronized to the latest XML file release from **Motor Styrelsen**.

## Running the application through Docker:

Build all the included docker images.

    docker build -t motorregister-base -f DockerfileBase .
    docker build -t motorregister-api -f ./MotorRegister.Api/Dockerfile .
    docker build -t motorregister-indexer -f ./MotorRegister.Api/Dockerfile .

