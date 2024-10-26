# User Management API

## Table of Contents

- [Description](#description)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [ERD Diagram](#diagram)
- [Installation and Setup](#installation-and-setup)
    - [Prerequisites](#prerequisites)
    - [Clone the Repository](#clone-the-repository)
    - [Database Setup](#database-setup)
    - [Backend Setup](#backend-setup)
    - [Run the API](#run-the-api)
- [Project Structure](#project-structure)

## Description 

The **User Management API** is a .NET 8 Web API designed to handle user registration.

## Features 

- **User Registration:** Allows users to register with necessary details.
- **Data Validation:** Ensures data integrity with comprehensive validation rules.
- **Swagger Documentation:** Provides interactive API documentation for easy testing and integration.

## Technologies Used 👾

### Back-end

- **ASP.NET 8 Web API**
- **Entity Framework Core**
- **Fluent API**
- **Repository Pattern**
- **Data Transfer Object (DTO) Pattern**
- **Dependency Injection**
- **SOLID Principles**
- **(DDD) for modeling object**

### Database

- **SQL Server**


## Diagram

![image](https://github.com/user-attachments/assets/183dab64-1577-4ceb-a6bb-ee3aa5c5d471)


## Installation and Setup 🚀

### Prerequisites ✅

Before setting up the project locally, ensure you have the following installed:

- **SQL Server Management Studio (SSMS)** or any other database client with access to SQL Server (e.g., DBeaver, Azure Data Studio).
- **.NET 8 Runtime** installed on your local machine.
- **Visual Studio 2022** (preferred IDE).

### Clone the Repository

`git clone https://github.com/eaa11/User-Management.git cd User-Management`

### Database Setup

I used Entity Framework Core's **Code-First** approach to create the database, but you can use the provided SQL script.

1. **Using Entity Framework Core:**
    
    - Open the solution in Visual Studio.
    - Open the **Package Manager Console** and run:
      
        `Update-Database`
        
2. **Using SQL Script:**
    
    - Locate the `userdb_script.sql` file in the root of the project.
    - Open **SQL Server Management Studio (SSMS)** and connect to your local server.
    - Execute the `userdb_script.sql` script to create the `db_user` database.

### Backend Setup

1. **Open the Solution:**
    
    - Navigate to the project directory.
    - Open `UserManagement.sln` in **Visual Studio 2022**.
2. **Configure Connection String:**
    
    - Go to `UserManagement.API/Config/appsettings.json`.
    - Update the `"DefaultConnection"` string to match your local SQL Server setup:
                
        `"ConnectionStrings": {   "DefaultConnection": "Data Source=localhost;Initial Catalog=db_user;Trusted_Connection=True;TrustServerCertificate=True;" }`
        

### Run the API 🚀

1. **Start the API:**
   
2. **Access Swagger UI:**
    
    - Once the API is running, navigate to `https://localhost:{PORT}/swagger` in your browser.
    - You should see the Swagger endpoint similar to the image below:
    
    ![Swagger UI](https://github.com/user-attachments/assets/8500b232-12da-4d51-a2b4-4170a83ee70d)
    

### Example Request

To register a new user, send a POST request to `/api/users` with the following JSON body:

<pre> { "name": "John Doe", "email": "john.doe@example.com", "password": "Pass123@", "phones": [ { "number": "4567890", "cityCode": "123", "countryCode": "1" } ] } </pre>

**Password Requirements:**

- At least one lowercase letter
- At least one uppercase letter
- At least one digit
- At least one special character
- Minimum of 8 characters


**You can configure password pattern :**
    
    - Update the `"RegexPattern"`:
                
        `"PasswordSettings": {   "RegexPattern": "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[\\W_]).{8,}$" }`

## Project Structure 🧱

```
UserManagement/
├── Common/
│   ├── Abstractions/
│   │   └── Interfaces and abstract classes for shared contracts
│   ├── Constants/
│   │   └── Constant values used throughout the project
│   ├── Extensions/
│   │   └── Extension methods to extend functionalities
│   └── ValidationException.cs
├── Config/
│   ├── appsettings.json
│   ├── appsettings.Development.json
│   └── PasswordSettings.cs
├── Features/
│   └── Users/
│       ├── Dtos/
│       │   └── Data Transfer Objects for data exchange
│       ├── Endpoints/
│       │   └── API endpoints
│       ├── Entities/
│       │   └── Database entities
│       ├── Requests/
│       │   └── Request models for handling incoming data
│       └── Services/
│           └── Business logic for user operations
├── Infrastructure/
│   ├── EntityConfiguration/
│   │   └── Configures database entity mappings
│   ├── Migrations/
│   │   └── Manages database migrations
│   └── Repositories/
│       └── Provides access to database operations
├── UserManagement.API/
│   ├── Program.cs
├── UserManagement.sln
*
