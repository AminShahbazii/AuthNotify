# Authentication System

A modular microservices system built with **ASP.NET Core**, consisting of:

- ✅ **Authentication API** — JWT-based user authentication and refresh token management.
- ✅ **Notification Service** — Email notification system using RabbitMQ + MassTransit.
- 🐳 **Dockerized** with support services: SQL Server, RabbitMQ, and Seq logging.

> 🧱 Clean Architecture + Microservice Principles + Docker

---

## ✨ Features

- ✅ User registration, login, and refresh tokens
- ✅ User management and role-based authorization
- ✅ Clean Architecture with EF Core & Code-First migrations
- ✅ Email notifications (welcome/custom)
- ✅ RabbitMQ messaging with MassTransit
- ✅ Centralized logging via Serilog & Seq
- ✅ Docker-based deployment (Multi-container)

---

## 🔧 Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [Docker](https://www.docker.com/)
- [Git](https://git-scm.com/)

---

## 🚀 Quick Start (Dockerized)

1. Clone the repository:

```bash
git clone https://github.com/yourusername/AuthNotify.git
cd AuthNotify
```

2. Create a `.env` file in the root:

```env
# SQL Server
SQLSERVER_PASSWORD=Password123?

# RabbitMQ
RABBITMQ_USER=guest
RABBITMQ_PASS=guest

# Database connection string
CONNECTION_STRING_DEFAULT_CONNECTION='Server=sqlserver;Database=databaseName;User Id=sa;Password=Password123?;TrustServerCertificate=true;Encrypt=false'

# JWT Secret
SIGNIN_KEY=SigingKey

# .NET Hosting URL
ASPNETCORE_URLS=http://0.0.0.0:80

# Seq
SEQ_FIRSTRUN_ADMINPASSWORD=Password123!

# Email (Mailtrap or other SMTP provider)
EMAIL_USER_NAME=username
EMAIL_PASSWORD=password
EMAIL_FROM=email@example.com
```

3. Build & Run all services:

```bash
docker-compose up --build
```

---

## 🧪 Services Overview

### 🔐 Authentication API

- Port: `http://localhost:7001`
- Supports:
  - Register / Login / Refresh Token
  - Scalar API docs: `http://localhost:7001/scalar/v1`

### ✉️ Notification Service

- Port: `http://localhost:5001`
- Send emails via:
  
  ```http
  POST /api/content/custom
  Content-Type: application/json
  ```

  ```json
  {
    "to": "recipient@example.com",
    "subject": "Welcome!",
    "body": "Hello from NotificationService!",
    "emailType": "Welcome"
  }
  ```

- Scalar API docs: `http://localhost:5002/scalar-api-reference`

### 🐰 RabbitMQ

- Management UI: `http://localhost:15672`  
  (default: guest / guest)

### 📊 Seq (Logging)

- UI: `http://localhost:5341`
- Login: admin / Password123!

---

## 🧱 Project Structure

```plaintext
.
├── AuthenticationApp/         # Auth API (Clean Architecture)
├── NotificationService/       # Email microservice
├── docker-compose.yml         # Docker environment for all services
├── .env                       # Environment variables
└── README.md
```

---

## 🧰 Development (Local)

You can run each service individually outside of Docker:

```bash
# Authentication API
cd AuthenticationApp
dotnet ef database update
dotnet run

# Notification Service
cd NotificationService
dotnet run
```

---

## 📌 Notes

- SQL Server and RabbitMQ must be running (either locally or via Docker).
- Emails are sent using **Mailtrap** by default.
- Logging is centralized in **Seq**, with correlation IDs for traceability.
- Use `Serilog`'s configuration in `appsettings.json` to control log levels or sinks.

---

## 🤝 Contributing

Pull requests welcome! For major changes, open an issue first to discuss what you’d like to change.

---

## 📄 License

This project is licensed under the MIT License.
