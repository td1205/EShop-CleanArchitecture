# EShop - Clean Architecture Project

## 🚀 Project Overview
A modern E-commerce backend system built with **.NET 8** following **Clean Architecture** principles.

## 🛠 Tech Stack
- **Backend:** .NET 8 Web API
- **Database:** SQL Server (running on **Docker**)
- **ORM:** Entity Framework Core (Code First)
- **Infrastructure:** Linux (WSL2) & Git

## 🏗 Architecture Layers
- **Domain:** Core entities and business logic.
- **Application:** Interfaces and DTOs.
- **Infrastructure:** Data persistence and external services.
- **API:** RESTful endpoints.

## ⚙️ How to Run
1. Start SQL Server: `docker-compose up -d`
2. Update Database: `dotnet ef database update`
3. Run Project: `dotnet run --project EShop.Api`
