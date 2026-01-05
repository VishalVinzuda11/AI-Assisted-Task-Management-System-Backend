# 📝 Task Management System

A full-stack **Task Management System** designed to manage tasks efficiently with a modern AI-assisted development workflow.  
The frontend is built using **Lovable.dev**, and the backend is developed in **ASP.NET Core** using **Cursor AI**.

---

## 📐 Architecture Overview

### High-Level Architecture

Frontend (Lovable.dev)  
⬇ REST API (HTTP/JSON)  
Backend (ASP.NET Core Web API)  
⬇  
Database (MySQL Server)

### Components

- **Frontend**
  - Built using **Lovable.dev**
  - Handles UI, task creation, updates, and task listing

- **Backend**
  - Developed using **ASP.NET Core Web API**
  - Implements business logic and validations
  - Handles CRUD operations for tasks
  - Exposes secured REST endpoints

- **Database**
  - MySQL Server
  - Stores task data such as title, description, status, and timestamps

---

## 🤖 AI Tools Used

This project was developed using AI-powered tools to improve productivity and code quality.

### 1. Lovable.dev
- Used for **frontend development**
- Auto-generated UI components
- Fast prototyping and layout generation
- Clean and responsive design

### 2. Cursor AI
- Used for **backend development**
- Assisted in:
  - Writing ASP.NET Core controllers
  - Entity models and DTOs
  - API integration and debugging
  - Error fixing and refactoring

---

## 💬 Prompt Examples

Below are some example prompts used during development:

### Frontend (Lovable.dev)
- *"Create a task management dashboard with task list, add task modal, and status filter"*
- *"Design a responsive form to add and edit tasks"*
- *"Generate a clean UI for task cards with status badges"*

### Backend (Cursor AI)
- *"Create an ASP.NET Core Web API for task CRUD operations"*
- *"Generate Task model with Id, Title, Description, Status, CreatedDate"*
- *"Write a controller with GET, POST, PUT, DELETE endpoints"*
- *"Fix CORS issue between frontend and backend"*

---

## ⚠️ Known Limitations

- No authentication or authorization implemented yet
- Role-based access (Admin/User) not available
- Basic validation only (no advanced business rules)
- No real-time updates (SignalR not implemented)
- Error handling can be improved
- UI customization limited to Lovable.dev templates

---

## 🚀 Future Improvements

- Add JWT-based authentication
- Implement user roles and permissions
- Add task priority and due dates
- Integrate real-time updates using SignalR
- Improve UI/UX with custom components
- Add unit and integration tests

---

## 🛠️ Tech Stack

- **Frontend:** HTML / CSS / TALWIND CSS / REACT / TYPESCRIPT
- **Backend:** ASP.NET Core Web API (.NET)
- **Database:** MySQL Server
- **Tools:** Cursor AI, Lovable.dev

---

