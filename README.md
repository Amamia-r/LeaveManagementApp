# 📝 Leave Management System API

An ASP.NET Core Web API project to manage employee leave requests with business rules, filtering, reporting, and admin approval.

---

## 🚀 Features

- ✅ CRUD operations on Leave Requests
- 🔎 Filtering, sorting, pagination & keyword search
- 📋 Summary reports by employee
- 🛡️ Business rules:
  - No overlapping leaves per employee
  - Max 20 annual leave days/year
  - Sick leave requires a reason
- 👨‍💼 Admin approval endpoint
- 🐳 Docker & Docker Compose setup
- 🧪 Postman collection included

---

## ⚙️ Tech Stack

- ASP.NET Core 8
- Entity Framework Core (SQLite)
- AutoMapper
- Swagger
- Docker

---

## 📦 Getting Started

### 🐳 Run with Docker

1. **Clone the repository**

```bash
git clone https://github.com/Amamia-r/LeaveManagementApp.git
cd LeaveManagementApp/API
```

2. **Run with Docker Compose**
```bash 
docker-compose up –build
```

3. **Access the API**
- Swagger UI: http://localhost:5123/swagger

---

## 🧪 API Testing
Import (LeaveRequests.postman_collection.json) into Postman to test all endpoints.

---

## 🧠 Self-Review & Improvements

### ✅ What Went Well
-	Clean architecture with Repository-Service-Controller layering
-	Applied business logic consistently (max days, overlapping detection, reason required)
-	Integrated AutoMapper for clean DTO transformation
-	Dockerized the app for easy deployment
-	Rich Swagger documentation
-	Flexible reporting with summary and filters

### 🔧 What Could Be Improved
-	Add JWT Authentication and Role-based authorization for admin/user split
-	Write unit tests for services and repositories
-	Add global error handling middleware
-	Improve validation with FluentValidation
-	Add CI/CD pipeline (GitHub Actions or Azure Pipelines)

---

## 👤 Author
- Mamiantsa Rasoanaivo
- GitHub: @amamia-r