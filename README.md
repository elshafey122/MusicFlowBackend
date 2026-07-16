# Music Distribution API

A RESTful ASP.NET Core Web API for managing artists, music tracks, and their distribution across Digital Service Providers (DSPs). The API follows Clean Architecture principles and uses JWT authentication to secure protected endpoints.

## Features

- Clean Architecture
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- JWT Authentication
- Input Validation
- Seeded Database
- Track Distribution Management
- Swagger / OpenAPI

---

## Prerequisites

Before running the project, make sure you have the following installed:

- .NET 8 SDK
- SQL Server
- Visual Studio 2022 (or Visual Studio Code)
- Git

---

## Clone the Repository

```bash
git clone <repository-url>
cd MusicFlowBackend
```

Replace `<repository-url>` with your GitHub repository URL.

---

## Configure the Database

Open the `appsettings.json` file and update the connection string if needed.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=MusicDistributionDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

---

## Apply Database Migrations

Open a terminal in the API project directory and run:

```bash
dotnet ef database update
```

Or use the Package Manager Console in Visual Studio:

```powershell
Update-Database
```

The database will be created automatically, and the seed data will be inserted.

---

## Run the Application

Run the project using the .NET CLI:

```bash
dotnet run
```

Or simply press **F5** in Visual Studio.

Once the application starts, Swagger will be available at:

```
https://localhost:<port>/swagger
```

---

## Authentication

The API uses **JWT Bearer Authentication**.

### Register

Create a new account by sending a POST request to:

```
POST /api/Auth/register
```

Example request body:

```json
{
  "userName": "john",
  "email": "john@example.com",
  "password": "Password@123"
}
```

---

### Login

Authenticate by sending a POST request to:

```
POST /api/Auth/login
```

Example request body:

```json
{
  "email": "admin@gmail.com",
  "password": "Admin@123"
}
```

Example response:

```json
{
  "token": "<jwt-token>"
}
```

Copy the returned JWT token.

---

## Using the JWT Token

To access protected endpoints in Swagger:

1. Run the API.
2. Open Swagger.
3. Click the **Authorize** button.
4. Enter the token in the following format:

```
Bearer <your-jwt-token>
```

Example:

```
Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```

5. Click **Authorize**.

You can now access all protected endpoints.

---

## Seed Data

The application automatically seeds the database with the following data:

### Artists

- 3 Artists

### Tracks

- 8 Tracks
- Multiple genres
- Different statuses

### Digital Service Providers (DSPs)

- 3 DSPs

### Users

#### Administrator

- Email: `admin@gmail.com`
- Password: `Admin@123`

#### Regular User

- Email: `user@gmail.com`
- Password: `User@123`

No manual data entry is required after running the migrations.

---

## Project Structure

```
src
│
├── MusicDistribution.API
├── MusicDistribution.Application
├── MusicDistribution.Domain
├── MusicDistribution.Infrastructure
└── MusicDistribution.Persistence
```

---

## Technologies

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- JWT Authentication
- Clean Architecture
- Swagger / OpenAPI

---

## Notes

- Make sure SQL Server is running before applying migrations.
- Update the connection string if your SQL Server instance differs from the default configuration.
- Ensure the frontend is configured to use the correct API URL if running both projects together.
