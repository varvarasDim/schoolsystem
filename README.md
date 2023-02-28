# schoolsystem

The solution contains the Domain Classroom that is a generic and get constructed with the use of the classes Teacher and Student.
The solution has the layers Controller and Service, the controller receives the requests and passes them to the service layer (SchoolService) where the Service layer
is responsible for passing the flow to the Domain.
The Classroom domain object is constructed as a singleton in order for its lifecycle to exist while the system runs.
The class SchoolService is constructed as a transient so that it does not have a "persistive" nature.


SCHEMA
Controller LAYER
|
DTO Object being transfered between the layers
|
SchoolService LAYER
|
Domain (Singleton for the usage of this example)


For the solution to be complete in the future, a persistence layer could be added below the Domain layer like a database etc.
Also addition of unit tests is going to be an improvement, in case the business logic is enhanced.
There are comments whereever was necessary in order to ensure that the code is understandable.