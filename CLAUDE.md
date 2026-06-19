# CLAUDE.md

## Project Name

Student Management Console App

## Project Purpose

This project is a simple C# Console Application for academic practical submission.

The goal is to build the project step by step using clean, simple code.

## Project Scope

The application must include:

* Student class with:

  * Id
  * Name
  * Email
  * EnrollmentDate
  * Grade

* StudentService with these methods:

  * Add
  * GetAll
  * GetById
  * UpdateGrade
  * Delete

* In-memory List<Student> storage only

* Simple menu-driven console UI in Program.cs

* At least 5 xUnit tests for StudentService

## Architecture

Use simple layered architecture:

* Models folder
  For the Student class

* Services folder
  For service interface and service implementation

* Program.cs
  For console menu and user interaction

* Test project
  For xUnit tests

## Development Rules

* Implement only the current prompt or milestone.
* Do not build the full project at once.
* Keep code simple, readable, and beginner-friendly.
* Follow basic SOLID principles.
* Follow common C# and .NET naming standards.
* Use meaningful class, method, and variable names.
* Avoid unnecessary complexity.
* Add comments only where they are useful.
* Run build after code changes.

## What To Avoid

Do not add:

* Database
* Entity Framework
* Web API
* DTOs
* AutoMapper
* Authentication
* Extra features not mentioned in the current prompt

## Coding Guidelines

* Use PascalCase for class names, methods, and properties.
* Use camelCase for local variables.
* Keep methods small and focused.
* Do not put business logic directly inside Program.cs.
* Put student-related operations inside StudentService.
* Use List<Student> as the only data storage.
* Keep validation simple and understandable.

## Testing Guidelines

* Use xUnit for testing StudentService.
* Write tests for main service methods.
* Keep test names clear and descriptive.
* Each test should check one behavior only.
* Do not test console input/output unless specifically asked.

## Important Instruction

Always follow the current prompt only.
Do not move to the next feature unless it is requested.
