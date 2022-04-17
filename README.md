How to install the project?
1. Clone or download zip files from github.com
2. Change defaultConnection in appsetting.json. The defaultConnection string must contain data to access your database (Host, Username, Password, Database). 
Note: database must be empty (just created)
3. Write "Add-Migration Init" to add first migration in the project in PM console.
4. Write "Update-Database" to implement changes/

Design Patterns:
1. Repository (to abstract data access layer)
2. Clean Architecture
3. Unit of Work

Technologies in the project:
1. Automapper (for easy mapping entities to dtos)
2. Swagger (Api documentation)
3. EF Core
4. FluentValidation (to validate dto)
5. Npgsql.EntityFrameworkCore.PostgreSQL (to work with PostgreSQL)///
