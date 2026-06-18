# Student Management Console App Instructions

## Project Scope

Build a simple C# Student Management Console App for academic practical submission.

Required features:
* 'Student' class with 'Id', 'Name', 'Email', 'EnrollmentDate', 'Grade'
* 'StudentService' with 'Add', 'GetAll', 'GetById', 'UpdateGrade', 'Delete'
* In-memory 'List<Student>' storage only
* Simple menu-driven console UI in 'Program.cs'
* At least 5 xUnit tests for 'StudentService'

## Development Rules
* Implement only the current prompt or milestone.
* Do not build the full project at once.
* Keep code simple, readable, and beginner-friendly.
* Do not add database, Entity Framework, API, repository pattern.
* Follow basic layered architecture.
* Follow basic SOLID principles.
* Follow common .NET naming and coding standards.
* Add validation only when the current milestone asks for it.

## Architecture
Use simple layers:

* 'Models' for the 'Student' class
* 'Services' for service interface and implementation
* 'Program.cs' for console menu UI
* Test project for xUnit tests

## Git Rule
After every successfully completed milestone:

* Run 'git add .'
* Commit with a simple milestone message

Example commit messages:
* 'Add Student model'
* 'Add student service interface'
* 'Implement StudentService methods'


## Avoid

Do not add:

Database
Entity Framework
Web API
Repository pattern