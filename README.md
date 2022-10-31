# Invoiceify(work in progress)

Application to handle invoices.

## How to launch
1. Clone this repository (master branch).
2. Open NuGet Package Manager Console.
3. Change the directory to the one with Invoiceify.Entities project.
4. Create a migration.
```bash
dotnet ef migrations add Initial
```
5. Update database.
```bash
dotnet ef database update
```
6. Set Invoiceify.API as startup project
7. Run the application.

## NuGet Packages
* AutoMapper
* Swashbuckle
* NLog
* EntityFramework
