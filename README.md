# EmployeeManager

A console-based employee management system built with **C#** and **Entity Framework Core**, backed by **SQL Server**. The application allows you to manage employees and departments through an interactive terminal interface.

---

## Features

- Add, view, update, and delete employee records
- Manage departments and assign employees to them
- Persistent data storage via SQL Server using EF Core
- Clean MVC-style architecture with separate layers for Models, Controllers, and UI

---

## Tech Stack

| Component        | Technology                          |
|------------------|-------------------------------------|
| Language         | C# (.NET 10)                        |
| ORM              | Entity Framework Core 10.0.6        |
| Database         | Microsoft SQL Server                |
| Architecture     | Console app with MVC-style layering |

---

## Project Structure

```
EmployeeManager/
├── Controllers/          # Business logic layer
├── Migrations/           # EF Core database migrations
├── Models/               # Entity models (Employee, Department)
├── UI/                   # Console interface and user interaction
├── ApplicationDbContext.cs  # EF Core DbContext configuration
├── Program.cs            # Application entry point
└── EmployeesManager.csproj
```

---

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Microsoft SQL Server (local or remote instance)
- `dotnet-ef` CLI tool

---

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/dev-joee/EmployeeManager.git
cd EmployeeManager
```

### 2. Configure the database connection

Open `ApplicationDbContext.cs` and update the connection string to match your SQL Server instance:

```csharp
private const string ConnectionString =
    "Data Source=localhost,1433;Initial Catalog=EmployeesManager;" +
    "User ID=<your_user>;Password=<your_password>;" +
    "Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True;";
```

> **Note:** Avoid committing credentials to version control. Consider moving the connection string to an environment variable or a configuration file.

### 3. Apply database migrations

```bash
dotnet ef database update
```

### 4. Run the application

```bash
dotnet run
```

---

## Database Schema

The application manages two core entities:

**Employee**
- Stores individual employee records
- Linked to a Department

**Department**
- Represents organizational units
- Can have multiple employees assigned

---

## Development

To add a new migration after modifying models:

```bash
dotnet ef migrations add <MigrationName>
dotnet ef database update
```

---

## Author

**Joe** — [github.com/dev-joee](https://github.com/dev-joee)