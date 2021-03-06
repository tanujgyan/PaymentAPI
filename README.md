# PaymentAPI
ASP.NET Core Web API CRUD with Angular 11. Prerequisites:

1) Install 4 packages 
1. Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation: Runtime compilation support for Razor views and Razor Pages in ASP.NET Core MVC.
2. Microsoft.EntityFrameworkCore: Entity Framework Core is a lightweight and extensible version of the popular Entity Framework data access technology.
3. Microsoft.EntityFrameworkCore.SqlServer: Microsoft SQL Server database provider for Entity Framework Core.
4. Microsoft.EntityFrameworkCore.Tools: Entity Framework Core Tools for the NuGet Package Manager Console in Visual Studio.

2) Run the following commands to import your EF classes to DB

1. add-migration AddPaymentToDB
2. update-database

3) Before you run EF command make sure:
1. Create Model class
2. Create ApplicationDbContext class
3. Add connection string to appsettings.json
4. Use dependency injection to add db context to startup.cs

To Install angular 11
1) Install node js and npm. Check version using node -v and npm -v
2) Run npm install -g @angular/cli
3) Create a new project ng new PaymentApp
4) In cmd go to the folder and type code . to open the folder in vs code

Angular Project Files
  1. Create a component using ng g c payment-details
  2. Inside that create a child component ng g c payment-details/payment-detail-form
  3. Create a shared folder and inside that we create service and model files ng g s shared/payment-detail-service and ng g class shared/payment-detail --type=model
