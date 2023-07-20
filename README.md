# qotd-csharp
Quote of the Day microservice written in C# (.NET Core 6)


## To establish database
`az extension add --name rdbms-connect --version 1.0.3`  

`az mysql flexible-server execute -n qotd -u mysqladmin -p "adminpassword" -f "qotddb.sql"`