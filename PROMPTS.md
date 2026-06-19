# Prompts Used — Student Management Console App

---

## Prompt 1 — Project Orientation

```
Role: Act as a C# .NET developer.

Context: I am building a Student Management Console App using layered architecture.
         The project setup and layers are already created.

Task: Have the knowledge of project using CLAUDE.md.

Constraints:
  - Do not implement anything yet.
```

**Purpose:** Orient Claude to the project scope and rules in CLAUDE.md before any code was written.

---

## Prompt 2 — Student Entity

```
Role: Act as a C# .NET developer.

Context: I am building a Student Management Console App using layered architecture.
         The project setup and layers are already created.

Task: Create a Student entity with the following properties:
      Id, Name, Email, EnrollmentDate, Grade

      Place the class in the correct Domain/Models layer.

Format:
  - Provide clean C# code with proper namespace, class name, and properties.

Constraints:
  - Implement only the Student class.
  - Do not add business logic in the entity.
  - Do not add exception handling in the entity.
  - Do not add service, repository, or tests yet.
  - Commit with message: Add Student model.
```

**Output:** `src/StudentManagement.Domain/Models/Student.cs` was created with `Id`, `Name`, `Email`, `EnrollmentDate`, and `Grade` properties.

---

## Prompt 3 — StudentService

```
Role: Act as a C# .NET developer.

Context: The Student entity is already created in the Domain/Models layer.
         I am building a Student Management Console App using layered architecture.

Task: Create a StudentService interface and StudentService implementation.

      1. Create an interface for StudentService with the following methods:
         Add
         GetAll
         GetById
         UpdateGrade
         Delete

      2. Create a StudentService class implementing its interface.

      Implement all methods using in-memory List<Student> storage only.

      Place the interface in the Application/Interfaces folder.
      Place the StudentService class in the Application/Services folder.

Format:
  - Provide clean C# code with proper namespace, class name, method signatures, and required using statements.

Constraints:
  - Use only an in-memory List<Student>.
  - Do not use DTOs.
  - Do not use AutoMapper.
  - Add basic validation using FluentValidation where needed.
  - Return appropriate exceptions where needed and cover all validations.
  - Commit with message: Add and implement StudentService.
```

**Output:**

* `IStudentService.cs` was placed in the Application interface layer.
* `StudentService.cs` was created with `Add`, `GetAll`, `GetById`, `UpdateGrade`, and `Delete`.
* `StudentValidator` was used for FluentValidation.
* `ValidationException`, `KeyNotFoundException`, `InvalidOperationException`, and `ArgumentException` were used where required.
* At this stage, in-memory `List<Student>` storage was directly inside `StudentService`.

---

## Prompt 4 — Refactor Student Storage Into Repository

```
Role: Act as a C# .NET developer.

Context: I am building a Student Management Console App using layered architecture.
         The project is partially layered.

         The project already has:
         Student model in the Domain layer
         StudentValidator using FluentValidation
         IStudentService interface
         StudentService implementation
         In-memory storage currently written directly inside StudentService

         StudentService is currently violating SRP.

Current issue:
StudentService is handling business logic, validation, and in-memory data storage together.

I want to improve the design slightly so it follows layered architecture and basic SOLID principles better,
especially Single Responsibility Principle and Dependency Inversion Principle.

Task: Refactor the code by moving the in-memory List<Student> storage out of StudentService into a separate repository.

Create the following:

1. IStudentRepository interface

   Place this interface inside:

   StudentManagement.Application/Interfaces

   Define all interfaces inside the separate Application/Interfaces folder.

   IStudentRepository should contain these methods:

   Add(Student student)
   GetAll()
   GetById(int id)
   ExistsByEmail(string email)
   Update(Student student)
   Delete(Student student)

2. StudentManagement.Infrastructure project

   Create a separate project named:

   StudentManagement.Infrastructure

   Inside this project, create a Repositories folder.

   Inside the Repositories folder, create:

   InMemoryStudentRepository

3. InMemoryStudentRepository class

   This class should:
   Implement IStudentRepository
   Use private List<Student> for in-memory storage
   Handle student ID generation internally
   Return student data from memory only

4. Refactor StudentService

   StudentService should:
   Depend on IStudentRepository
   Depend on IValidator<Student>
   Use IValidator<Student> instead of directly creating StudentValidator
   Keep only business logic
   Use repository for data access
   Keep duplicate email check
   Keep grade update logic

5. Project references

   Add required project references so the solution builds successfully.

   StudentManagement.Infrastructure should reference:

   StudentManagement.Application
   StudentManagement.Domain

   StudentManagement.ConsoleUI should reference:

   StudentManagement.Infrastructure

Format:
  - Provide clean C# code with proper namespaces.
  - Include required using statements.
  - Use correct folder structure.
  - Use separate files for each interface and class.
  - Give a short explanation of what changed and why.

Constraints:
  - Use in-memory storage only.
  - Do not add database.
  - Do not add Entity Framework.
  - Do not add API or controller.
  - Do not add DTOs.
  - Do not add AutoMapper.
  - Do not modify unrelated files.
  - Only related and dependent changes are allowed.
  - After modifications, the project should be in working condition.
  - Run build after changes.
  - Commit with message: Refactor student storage into repository.
```

**Output:**

* `IStudentRepository.cs` was added inside `StudentManagement.Application/Interfaces`.
* A separate `StudentManagement.Infrastructure` class library project was added.
* `Repositories/InMemoryStudentRepository.cs` was added inside the Infrastructure project.
* In-memory `List<Student>` storage and ID generation were moved from `StudentService` to `InMemoryStudentRepository`.
* `StudentService` was refactored to depend on `IStudentRepository` and `IValidator<Student>`.
* Required project references were added so the solution could build successfully.

---

## Prompt 5 — Console Menu Structure

```
Role: Act as a C# .NET developer.

Context: The Student model, StudentService, validator, and in-memory repository are already implemented.
         I am now creating the console UI.

Task: Create a simple menu-driven console UI in Program.cs with options:

      1. Add Student
      2. View All Students
      3. View Student By Id
      4. Update Student Grade
      5. Delete Student
      6. Exit

      Create the menu structure and call separate methods for each option.

Format:
  - Provide clean C# code for Program.cs and simple menu flow.

Constraints:
  - Implement only the menu structure.
  - Do not add advanced UI.
  - Do not add database.
  - Commit with message: Add console menu UI.
```

**Output:** `Program.cs` was updated with a simple menu loop, switch case, and separate method structure for each menu option.

---

## Prompt 6 — Implement Program.cs Methods

```
Role: Act as a C# .NET developer.

Context: The Student model, StudentService, validator, and in-memory repository are already implemented.
         Program.cs has the console menu structure.

Task: Implement each menu method to call the StudentService in working condition.

Format:
  - Provide clean C# code for Program.cs methods.

Constraints:
  - Keep the console UI simple and readable.
  - Use StudentService methods for Add, GetAll, GetById, UpdateGrade, and Delete.
  - Handle exceptions with clear console messages.
  - Create required service, repository, and validator objects properly.
  - Do not add database.
  - Commit with message: Implement Program.cs methods.
```

**Output:**

* All menu methods in `Program.cs` were implemented.
* Console input was collected for student details.
* `StudentService` methods were called from the UI.
* Exceptions were handled with clear console messages.
* Required objects such as `InMemoryStudentRepository`, `StudentValidator`, and `StudentService` were created properly.

---

## Prompt 7 — xUnit Tests

```
Role: Act as a C# .NET developer.

Context: The xUnit test project is already created and connected to the main project.

         StudentService has Add, GetAll, GetById, UpdateGrade, and Delete methods.

         StudentService now depends on:
         IStudentRepository
         IValidator<Student>

Task: Write 5 xUnit tests for StudentService.

Cover these cases:

Add student successfully
Get all students
Get student by Id
Update student grade
Delete student

Format:
  - Provide clean xUnit test code with Arrange, Act, Assert structure.

Constraints:
  - Write only StudentService tests.
  - Keep tests simple and readable.
  - Create required test dependencies such as InMemoryStudentRepository and StudentValidator.
  - Do not add database.
  - Do not test UI.
  - Commit with message: Add xUnit tests for StudentService.
```

**Output:** `StudentServiceTests.cs` was updated with five `[Fact]` tests using Arrange, Act, Assert structure. Each test used required dependencies such as `InMemoryStudentRepository`, `StudentValidator`, and `StudentService`.

---
