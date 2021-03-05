# PaymentAPI
ASP.NET Core Web API CRUD with Angular 11
Install 4 packages 
1. Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation: Runtime compilation support for Razor views and Razor Pages in ASP.NET Core MVC.
2. Microsoft.EntityFrameworkCore: Entity Framework Core is a lightweight and extensible version of the popular Entity Framework data access technology.
3. Microsoft.EntityFrameworkCore.SqlServer: Microsoft SQL Server database provider for Entity Framework Core.
4. Microsoft.EntityFrameworkCore.Tools: Entity Framework Core Tools for the NuGet Package Manager Console in Visual Studio.

Run the following commands to import your EF classes to DB

add-migration AddPaymentToDB
update-database

Before you run EF command make sure:
1. Create Model class
2. Create ApplicationDbContext class
3. Add connection string to appsettings.json
4. Use dependency injection to add db context to startup.cs
