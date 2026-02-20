**.NET**
---
- **Create an initial migration:**: `dotnet ef migrations add InitialCreate` 
- **Create a new migration:** `dotnet ef migrations add AddBlogCreatedTimestamp`
    - I'm pretty sure the use cases for these are the same. You can probably pass any name to the command and it will just either create the initial migration or an updated one. 
- **Update the database with the latest migration:** `dotnet ef database update`
- **Connect to the database from the CLI:** `sqlcmd -S localhost,1433 -U sa -P "[password]" -C`

**React:**
---
- 