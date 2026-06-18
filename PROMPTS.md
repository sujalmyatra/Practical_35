# Prompts Used — Student Management Console App

---

## Prompt 1 — Project Orientation

```
Role: Act as a C# .NET developer.
Context: I am building a Student Management Console App using layered architecture.
         The project setup and layers are already created.
Task: Have the knowledge of project using CLAUDE.md.
Constraints: Do not implement anything yet.
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
Constraints:
  - Implement only the Student class.
  - Do not add business logic in the entity.
  - Do not add exception handling in the entity.
  - Do not add service, or tests yet.
```

**Output:** `src/StudentManagement.Domain/Models/Student.cs` with five auto-properties and empty defaults.

---

## Prompt 3 — StudentService

```
Role: Act as a C# .NET developer.
Context: The Student entity is already created in the Domain/Models layer.
Task: Create a StudentService interface and StudentService implementation.

      1. Create an interface for StudentService with methods:
         Add, GetAll, GetById, UpdateGrade, Delete
      2. Create a StudentService class implementing its interface.
         Use in-memory List<Student> storage only.
      Place interface and class in the correct Application/Services layer.

Constraints:
  - Use only an in-memory List<Student>.
  - Do NOT use DTOs, AutoMapper.
  - Add basic validation using FluentValidation where needed.
  - Return appropriate exceptions where needed.
```

**Output:**
- `IStudentService.cs` and `StudentValidator.cs` were already present — Claude recognised this and skipped re-creating them.
- Created `StudentService.cs` with `Add`, `GetAll`, `GetById`, `UpdateGrade`, `Delete`.
- `ValidationException` on bad input, `KeyNotFoundException` for missing IDs, `InvalidOperationException` for duplicate email.

---

## Prompt 4 — Console Menu Structure

```
Role: Act as a C# .NET developer.
Context: The Student model and StudentService are already implemented.
Task: Create a simple menu-driven console UI in Program.cs with options:
      1. Add Student  2. View All Students  3. View Student By Id
      4. Update Student Grade  5. Delete Student  6. Exit
      Create the menu structure and call separate methods for each option.
Constraints:
  - Implement only the menu structure.
```

**Output:** `Program.cs` with a `while` loop, `switch` on input, and five empty local functions as stubs.

---

## Prompt 5 — Implement Program.cs Methods

```

Role: Act as a C# .NET developer.
Context: The Student model and StudentService are already implemented, Program.cs partially implemented.
Task: Implement each menu method to call the StudentService, in working condition.

```

**Output:** All five local functions filled in with console input, `StudentService` calls, and exception handling. A shared `DisplayStudent` helper was added to avoid repeated formatting code.

---

## Prompt 6 — xUnit Tests

```
Role: Act as a C# .NET developer.
Context: The xUnit test project is already created and connected to the main project.
         StudentService has Add, GetAll, GetById, UpdateGrade, and Delete methods.
Task: Write 5 xUnit tests for StudentService.
      Cover: Add student, Get all, Get by Id, Update grade, Delete student.
Format: Arrange / Act / Assert structure.
Constraints:
  - Write only StudentService tests.
  - Keep tests simple and readable.
```

**Output:** `StudentServiceTests.cs` with five `[Fact]` tests, each with its own fresh `StudentService` instance and a `CreateValidStudent()` helper satisfying all FluentValidation rules.
