# 🏥 HCAMiniEHR – Mini Electronic Health Record System

## 📌 Project Overview
**HCAMiniEHR** is a mini Electronic Health Record (EHR) system developed as a capstone project to demonstrate end-to-end backend and frontend development using **ASP.NET Core Razor Pages**, **Entity Framework Core**, **SQL Server**, **LINQ**, and **Git**.

The application manages:
- Patients
- Appointments
- Lab Orders

It also includes database auditing, stored procedure integration, and LINQ-based reporting.

---

## 🎯 Objective
To apply all learning from the course:
- Git & GitHub workflow  
- SQL Server (tables, triggers, stored procedures)  
- Entity Framework Core  
- LINQ queries  
- ASP.NET Core Razor Pages  

This project simulates a real-world healthcare management module.

---

## 🛠 Tech Stack
- Framework: ASP.NET Core Razor Pages (.NET 8)
- ORM: Entity Framework Core
- Database: SQL Server
- UI: Razor Pages + Bootstrap
- Version Control: Git & GitHub
- IDE: Visual Studio 2022

---

## 🗂 Project Structure
HCAMiniEHR
│
├── Data
│ └── ApplicationDbContext.cs
│
├── Models
│ ├── Patient.cs
│ ├── Appointment.cs
│ ├── LabOrder.cs
│ └── AuditLog.cs
│
├── Repositories
│ ├── Interfaces
│ │ ├── IPatientRepository.cs
│ │ ├── IAppointmentRepository.cs
│ │ └── ILabOrderRepository.cs
│ │
│ ├── PatientRepository.cs
│ ├── AppointmentRepository.cs
│ └── LabOrderRepository.cs
│
├── Services
│ ├── PatientService.cs
│ ├── AppointmentService.cs
│ └── LabOrderService.cs
│
├── Pages
│ ├── Patients
│ ├── Appointments
│ ├── LabOrders
│ └── Reports
│
├── Migrations
│
├── SQL
│ ├── Triggers.sql
│ └── StoredProcedures.sql
│
└── README.md

---

## ✅ Features Implemented

### 1️⃣ EF Core Models
- Patient
- Appointment
- LabOrder
- AuditLog

Relationships:
- One Patient → Many Appointments  
- One Appointment → Many LabOrders  

---

### 2️⃣ Database Migrations
- Code-First approach using EF Core
- Tables created under **Healthcare** schema
- Supports schema updates via migrations

---

### 3️⃣ Repository Layer
- Repository pattern implemented for data access
- Interfaces used for abstraction and testability
- EF Core DbContext injected into repositories

Repositories:
- `IPatientRepository`
- `IAppointmentRepository`
- `ILabOrderRepository`

---

### 4️⃣ Service Layer
- Business logic handled in services
- Services consume repositories (not DbContext directly)
- Keeps Razor Pages thin and clean

---

### 5️⃣ CRUD Operations
CRUD functionality implemented for:
- Patients
- Appointments
- Lab Orders

---

### 6️⃣ LINQ Reports
LINQ queries implemented using:
- Where
- Select
- GroupBy
- Join
- OrderBy

#### Available Reports:
1. Pending Lab Orders (Status = 'Pending')
2. Patients Without Follow-Up (no future appointment)
3. Doctor Productivity (optional bonus)

---

### 7️⃣ Database Audit (Trigger)
- SQL trigger on Appointment table
- Logs INSERT, UPDATE, DELETE actions
- Stores logs in **AuditLog** table

---

### 8️⃣ Stored Procedure Integration
- Stored Procedure: `CreateAppointment`
- Executed from C# using EF Core
- Demonstrates hybrid EF Core + SQL usage








