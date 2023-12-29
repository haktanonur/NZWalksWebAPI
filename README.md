# ASP.NET Core Web API 

Using the ASP .NET Core Web API, I created a very interesting REST API that includes the regions and walks of New Zealand

## Achievements
- Understand REST APIs by creating a Web API using ASP.NET Core and .NET 7

- Understand Dependency Injection and Benefits

- Learn And Install Entity Framework Core (EF Core) In ASP.NET Core Web API Project

- Learn Entity Framework Core Migrations

- Understand the difference between Domain models and DTOs

- Understand Domain Models and Repository Pattern

- Use Swagger To Test ASP .NET Core WEB API project

- Learn How To Map Models To One Another Using Automapper

- Learn Asynchronous Programming (Async Await)

- Learn Logging In ASP.NET Core Web API Project

- Secure your ASP.NET Core Web API using Microsoft Identity by adding Authentication and Role-Based Authorization to your REST API.

- Add JWT Authentication to ASP.NET Core Web API by creating JWT Tokens to API Clients.

- Incorporate ASP.NET JWT Authentication Into SwaggerUI

- Add advanced functionality like Filtering, Sorting, and Pagination to your ASP.NET Core Web API.


## Technologies and Tools
 
- C#
- .NET 7.0
- ASP .NET Core Web API
- Entity Framework Core
- SQL Server
- Automapper 
- Json Web Token (JWT)
- Serilog
- Postman
- Swagger UI

## How to Run
These steps are designed to help someone who has cloned the project to get it running on their local machine.

### Prerequisites
- .NET 7.0 SDK
- SQL Server

### Steps
#### 1. Clone the Repository
Open Terminal or Command Prompt and clone the repository to your local machine:

```
git clone <https://github.com/haktanonur/aspnetcore-web-api-nzwalks.git>
```
#### 2. Install Dependencies
Navigate to the project's root directory in Terminal or Command Prompt:

```
cd aspnetcore-web-api-nzwalks
```

Install dependencies using the following command:
```
dotnet restore
```
#### 3. Set Up the Database Connection
Update the SQL Server connection string in the appsettings.json file:

```
"ConnectionStrings": {
  "NZWalksConnectionString": "Server=<server_name>;Database=<NZWalksDb>;Trusted_Connection=True;MultipleActiveResultSets=true",

  "NZWalksAuthConnectionString": "Server=server_name;Database=NZWalksAuthDb;Trusted_Connection=True;TrustServerCertificate=True"
}

```
Replace <server_name> with your SQL Server information.

#### 4. Create the Database

Navigate to the project directory in Terminal or Command Prompt and run the following command:

```
dotnet ef database update
```

#### 5. Run the Project

Navigate to the project directory in Terminal or Command Prompt and start the application:

```
dotnet run
```

![image](https://github.com/haktanonur/aspnetcore-web-api-nzwalks/assets/69698425/21552907-5ee9-422d-8c0d-f13a596f5805)
