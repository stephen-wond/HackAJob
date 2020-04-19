# HackAJob
Phonebook API

Running 'update-database' on the Package Manager Console will create the database via EF migrations
Database is seeded with some initial data.


Calling the following will return a JWT token:
'../api/Login/Login?username=Steve&password=123'


Calling the following with the JWT token obtained from above will allow you to access the phonebook:
'../api/Contacts/'


The following methods are avaliable for Contacts:
GET()
POST()
GET(id)
PUT(id)
DELETE(id)