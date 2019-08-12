# RMS.Training
Service is built on .Net Core 2.1. This program uses in memory database to save records using Entity Framework Core.  This can be changed and connected to any database, and can create using Entity Framework Core Code first approach as well but as in memory database is sufficing the need and there was no requirement of fetching records from database I opted to use in memory.
Design decisions

1.	.Net Core api is used to connect to Angular SPA. 
2.	To run the Api, it can be hosted on port 5000, and 
3.	.Net core api is configured with swagger URL locahost:5000/swagger
4.	Api controller test cases are written using XUnit
5.	Angular component test cases are written in Jasmine and use karma to run
6.	On opening angular app  in vs code, angular test cases can be run by running
‘ng test’ command, in VS Code terminal


List of service api

Action | Method | Route
------------ | ------------- |--------
NewTraining	|Post request. Returns success message and statuscode or exception.	| api/new

