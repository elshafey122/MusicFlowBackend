# Music Distribution API

A RESTful ASP.NET Core Web API for managing artists, tracks, and DSP (Digital Service Provider) distributions.

## Features

- Clean Architecture
- Entity Framework Core
- SQL Server
- JWT Authentication
- Input Validation
- Seeded Database
- Track Distribution Management

---

## Prerequisites

Make sure you have installed:

- .NET 10 SDK
- SQL Server
- Visual Studio 2022 (or VS Code)
- Git

---

## Clone the Repository

```bash
git clone <repository-url>
cd MusicFlowBackend
```

---

## Configure the Database

Update the connection string inside:

```text
appsettings.json
```

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=MusicDistributionDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

---

## Apply Database Migrations

Open a terminal inside the API project and run:

```bash
dotnet ef database update
```

Or using Visual Studio Package Manager Console:

```powershell
Update-Database
```

The database will be created and seeded automatically.

---

## Run the Application

Using the .NET CLI:

```bash
dotnet run
```

Or simply press **F5** in Visual Studio.

Swagger will be available at:

```
https://localhost:<port>/swagger
```

---

## Authentication

The API uses JWT Bearer Authentication.

### Register

Send a POST request to:

```
POST /api/Auth/register
```

Example request body:

```json
{
  "userName": "admin",
  "email": "admin@example.com",
  "password": "Admin@123"
}
```

---

### Login

Send a POST request to:

```
POST /api/Auth/login
```

Example:

```json
{
  "email": "admin@example.com",
  "password": "Admin@123"
}
```

Response:

```json
{
  "token": "<jwt-token>"
}
```

Copy the returned token.

---

## Using the JWT Token

In Swagger:

1. Click **Authorize**.
2. Enter:

```
Bearer <your-token>
```

Example:

```
Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```

Click **Authorize**.

Protected endpoints can now be accessed.

---

## Seed Data

The application seeds the database with:

- 3 Artists
- 8 Tracks
- 3 DSPs
- 1 Admin   email=admin@gmail.com pass=Admin@123  
- 1 User    user=user@gmail.com   pass=User@123

No manual data entry is required.

---

## Project Structure

```
src
│
├── MusicDistribution.API
├── MusicDistribution.Application
├── MusicDistribution.Domain
├── MusicDistribution.Infrastructure
├── MusicDistribution.Persistence
```

---

## Technologies

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger/OpenAPI
