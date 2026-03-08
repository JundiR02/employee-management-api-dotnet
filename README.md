# Employee Management API (.NET)

A RESTful Employee Management API built with ASP.NET Core.  
This project demonstrates modern backend development practices including authentication, clean architecture, logging, and automated testing.

---

## Features

- JWT Authentication
- Role-Based Authorization (Admin/User)
- CRUD Employee Management
- Pagination & Filtering
- API Versioning
- Global Exception Handling Middleware
- Logging with Serilog
- AutoMapper for DTO Mapping
- Repository Pattern & Service Layer
- Unit Testing (xUnit + Moq)
- Integration Testing

---

## Tech Stack

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- AutoMapper
- Serilog
- xUnit
- Moq
- Swagger (OpenAPI)

---

## Project Structure

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

## Authentication

The API uses **JWT Bearer Token Authentication**.

Example login response:

```json
{
  "token": "jwt_token_here"
}
```

Use the token in requests:

```
Authorization: Bearer YOUR_TOKEN
```

---

## API Endpoints

### Authentication

```
POST /api/v1/auth/register
POST /api/v1/auth/login
```

### Employees

```
GET    /api/v1/employees
GET    /api/v1/employees/{id}
POST   /api/v1/employees
PUT    /api/v1/employees/{id}
DELETE /api/v1/employees/{id}
```

---

## Running the Project

Clone the repository:

```
git clone https://github.com/JundiR02/employee-management-api-dotnet.git
```

Navigate to the project:

```
cd DotnetPortofolio
```

Run the API:

```
dotnet run --project EmployeeApi
```

Swagger UI will be available at:

```
http://localhost:5169/swagger
```

---

## Running Tests

Run unit and integration tests:

```
dotnet test
```

---

## Logging

Logging is implemented using **Serilog**.  
Logs are stored in the `Logs` folder.

---

## Testing

This project includes:

- Unit Testing using **xUnit**
- Mocking using **Moq**
- Integration Testing using **WebApplicationFactory**

---

## Author

Backend Developer Portfolio Project  
Built with ASP.NET Core