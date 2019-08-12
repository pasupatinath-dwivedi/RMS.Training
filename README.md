# RMS.Training
Service is built on .Net Core 2.1. This program uses in memory database to save records using Entity Framework Core.  This can be changed and connected to any database, and can create using Entity Framework Core Code first approach as well but as in memory database is sufficing the need and there was no requirement of fetching records from database I opted to use in memory.


1.	Angular SPA is used as WebClient and connects to .Net Core 2.1 Api. 
2.	To run the Api, it can be hosted on port 5000,
3.	Api controller test cases are written using XUnit
4.	Angular component test cases are written in Jasmine and use karma to run

## Swagger 

.Net core api is configured with swagger URL 
Run the instance of Training Api and use below link for swagger

http://locahost:5000/swagger

## Running Angular unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## List of service api

Action | Method | Route
------------ | ------------- |--------
NewTraining	|Post request. Returns success message and statuscode or exception.	| api/new

