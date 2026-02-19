# Equipment Manager
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-10.0-green)
![React](https://img.shields.io/badge/React-19.2.4-blue)
![SQL Server](https://img.shields.io/badge/SQL_Server-2019-red)

Full-stack demo (and learning) project for internship portfolio.<br>
I will be learning how to work with the technologies first. Once I have, I will start creating branches and issues.<br>
The app is an internal equipment booking system, and the tech stack is loosely based on what is required for Microsoft's [AZ-204 certificate](https://learn.microsoft.com/en-us/credentials/certifications/azure-developer/?practice-assessment-type=certification).
## Tech stack
- Back end: ASP.NET Core, Entity Framework, SQL Server
- Frontend: React + TypeScript
- Deployment: Azure App Service

## Features
- CRUD for equipment
- CRUD for bookings
- Basic authentication and authorization (JWT)
- Front end dashboard

## Setup instructions
### Database
#### Linux
- The [Compose file](./database/docker-compose.yml) is needed to run SQL Server (as a dev database).
- To test the database with the CLI, use [this step-by-step](https://learn.microsoft.com/en-us/sql/linux/sql-server-linux-setup-tools?view=sql-server-ver17&tabs=ubuntu-install%2Codbc-ubuntu-2404#ubuntu) to set up `sqlcmd`.

## Deployment
...

## Endpoints
