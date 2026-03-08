# Employee Management API (.NET)

![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET-Core-green)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-red)
![xUnit](https://img.shields.io/badge/Testing-xUnit-orange)
![License](https://img.shields.io/badge/License-MIT-lightgrey)

A modern **Employee Management REST API** built with **ASP.NET Core** demonstrating best practices in backend development including authentication, clean architecture, logging, and automated testing.

---

# Features

- JWT Authentication
- Role-Based Authorization
- Employee CRUD Operations
- Pagination Support
- API Versioning
- Global Exception Handling Middleware
- Logging with Serilog
- DTO Mapping with AutoMapper
- Repository Pattern
- Service Layer Architecture
- Unit Testing with xUnit & Moq
- Integration Testing

---

# Tech Stack

Backend Framework

- ASP.NET Core Web API (.NET 8)

Database

- SQL Server
- Entity Framework Core

Libraries

- AutoMapper
- Serilog
- JWT Bearer Authentication

Testing

- xUnit
- Moq
- WebApplicationFactory

API Documentation

- Swagger / OpenAPI

---

# Project Structure

```
DotnetPortofolio
│
├── EmployeeApi
│   ├── Controllers
│   ├── Services
│   ├── Repositories
│   ├── Models
│   ├── DTOs
│   ├── Middleware
│   └── Data
│
├── EmployeeApi.Tests
│   ├── Services
│   └── IntegrationTests
│
└── DotnetPortofolio.sln
```

---

# Authentication

This API uses **JWT Bearer Token Authentication**.

Example login response:

```json
{
  "token": "your_jwt_token"
}
```

Use the token in requests:

```
Authorization: Bearer YOUR_TOKEN
```

---

# API Endpoints

Authentication

```
POST /api/v1/auth/register
POST /api/v1/auth/login
```

Employees

```
GET    /api/v1/employees
GET    /api/v1/employees/{id}
POST   /api/v1/employees
PUT    /api/v1/employees/{id}
DELETE /api/v1/employees/{id}
```

---

# Running the Project

Clone repository

```
git clone https://github.com/JundiR02/employee-management-api-dotnet.git
```

Navigate to project

```
cd DotnetPortofolio
```

Run the API

```
dotnet run --project EmployeeApi
```

Open Swagger

```
http://localhost:5169/swagger
```

---

# Running Tests

Run all unit and integration tests

```
dotnet test
```

---

# Logging

Logging is implemented using **Serilog**.

Logs are stored in the **Logs** directory.

---

# Testing

This project includes:

- Unit Testing with **xUnit**
- Mocking with **Moq**
- Integration Testing with **WebApplicationFactory**

---

# Author

**Jundi Robbani**

Backend Developer Portfolio Project built with ASP.NET Core