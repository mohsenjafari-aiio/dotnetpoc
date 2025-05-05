# 🧠 .NET 8 Clean Architecture POC by Mohsen Jafari

## 🚀 Getting Started

To run the project locally using Docker:

### 🐳 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (optional, for local development/debugging)
- [Docker & Docker Compose](https://docs.docker.com/get-docker/)

### 🔧 Run the Project

1. Clone the repository:

```bash
git clone https://github.com/mohsenjafari-aiio/dotnetpoc.git
cd aiio
```

2. Start the app and database with Docker:

```bash
docker-compose up --build
```

3. Access the API and database:

- API Swagger UI: [http://localhost:8080/swagger](http://localhost:8080/swagger)
- PostgreSQL: `localhost:5433`, username: `postgres`, password: `postgres`, database: `aiio_db`

---

## 📦 Project Overview

This is a proof-of-concept (POC) .NET 8 Web API built with Clean Architecture, Domain-Driven Design (DDD), and CQRS. It demonstrates a modular, testable, and production-aligned structure suitable for scalable enterprise systems.

It supports managing entities like Processes, Departments, Roles, Resources, and Locations, each modeled with domain behavior and exposed via a minimal HTTP API with proper validation, logging, and exception management.

---

## ✨ Features

- 🧱 Clean Architecture with strict layering and separation of concerns
- ✅ CQRS with MediatR for command/query orchestration
- 📚 Domain-driven behavior (rich domain models, not anemic)
- 🧪 Unit-tested core logic (domain, handlers, repositories)
- 🔧 FluentValidation + FluentResults for input and error handling
- 🐳 Dockerized PostgreSQL + Minimal API app
- 🌐 OpenAPI (Swagger) UI for easy API exploration
- 🔌 Dependency Injection and pipeline behaviors
- 🚀 Async-first, minimal-overhead runtime

---

## 🏗 Architecture Overview

| Layer             | Purpose                                                                 |
|------------------|-------------------------------------------------------------------------|
| **Domain**        | Core models, behaviors (e.g., `Process.AssignRole()`), exceptions, interfaces |
| **Application**   | Use-case orchestration, validation, MediatR command/query handlers      |
| **Infrastructure**| EF Core, DbContext, PostgreSQL setup, repo implementations              |
| **Contract**      | DTOs, Commands, Queries, Request/Response models                        |
| **Framework**     | CQRS abstractions, cross-cutting behaviors (validation, logging)        |
| **App**           | Minimal API, DI registration, Swagger, middleware setup                 |

---

## ✅ Why This Architecture Produces Clean Code

### 🔹 Separation of Concerns

Each layer has a single responsibility. This structure avoids tight coupling, improves clarity, and allows teams to work on layers independently.

### 🔹 Rich Domain Behavior

Entities expose methods to enforce rules internally (e.g., `ChangeName()`, `AssignRole()`), making the domain the authority for business logic.

### 🔹 CQRS for Predictable Flow

Each operation has a dedicated handler, making workflows easy to follow, debug, and test.

---

## 🔍 Why It’s Highly Testable

- **Domain logic** is isolated and can be tested without any framework or infrastructure.
- **Handlers** use dependency-injected repositories, making mocking easy.
- **Validators and behaviors** are tested independently.
- **xUnit tests** are provided for domain, repositories, and handlers.

---

## 📝 Logging & Exception Handling

### Request Logging via Pipeline Behaviors

All commands and queries are automatically logged using a `LoggingBehavior`:

- Logs request name, data, and result
- Applies globally to all handlers

### Centralized Error Handling with Middleware

A global `ExceptionMiddleware` catches and logs all unhandled exceptions:

- Captures stack trace, request path, timestamp
- Differentiates between domain, validation, and infrastructure errors
- Returns standardized JSON error response
- Keeps controller/handler code clean (no try/catch needed)

---

## 💻 Developer Experience & Runtime Benefits

- **OpenAPI/Swagger** UI available at `/swagger`
- **Works with Hot Reload** and .NET CLI
- **Fully async** for scalability
- **Minimal API = low overhead**
- **Ready for SignalR/WebSockets**
- **Docker-ready for quick onboarding**

---

## 🔐 Infrastructure & Integration

- PostgreSQL database, containerized via Docker Compose
- Scoped DbContext ensures proper connection handling
- Clean abstraction makes it easy to extend to Redis, RabbitMQ, etc.
- Secure by design: validation, error handling, layered architecture

---

## ✅ Summary

This POC proves that .NET 8 can deliver clean, scalable, testable APIs using modern backend practices. By applying Clean Architecture, DDD, and CQRS together, it provides:

- Clean, maintainable code
- Domain-driven integrity
- Predictable request flow
- Robust logging and error handling
- Fast setup with Docker

**Use it as a foundation, inspiration, or template for your own production-grade .NET APIs.**