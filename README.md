# devcenter_test1

Prerequisites:
       	- GIT
 		- Any IDE
 		- .NET Core 2.0
 		- SQL Server 2012+
    
    
     - Modify the database connection string as per your instance and authentication.
        - On any terminal move to the "DevContact.Domain" folder (the folder containing the "DevContact.Domain.csproj" file) and execute these commands:

        dotnet restore
        dotnet build
        dotnet ef database update

        - Now you can call the API using any tool, like Postman, Curl, etc
