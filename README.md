# Task Manager REST API

A backend REST API built using ASP.NET Core that allows users to manage tasks through CRUD operations.

## Technologies Used

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger (OpenAPI)

## Features

- Create tasks
- Retrieve all tasks
- Update tasks
- Delete tasks
- Persistent storage using SQL database
- API testing via Swagger UI

## Example Task Object

{
  "id": 1,
  "title": "Build portfolio project",
  "isCompleted": false
}

## API Endpoints

GET /api/tasks  
POST /api/tasks  
PUT /api/tasks/{id}  
DELETE /api/tasks/{id}

## Project Structure

Controllers – API endpoints  
Models – Database models  
DTOs – Data transfer objects  
Data – Database context

## Future Improvements

- Authentication with JWT
- Pagination
- Logging
- Unit testing
