# Reflection — AI-Assisted Development

**Project:** Student Management Console App  

---

## Where Claude Helped

### Layered architecture was respected without prompting
Claude correctly placed every file in the right layer — `Student.cs` in `Domain/Models`, `IStudentService` and `StudentService` in `Application/Services`, `StudentValidator` in `Application/Validators` — without needing explicit file-path instructions each time.

### Exception strategy was consistent
Across `StudentService` and `Program.cs`, Claude used the same exception types throughout: `ValidationException` for FluentValidation failures, `KeyNotFoundException` for missing records, `InvalidOperationException` for duplicate emails, and `ArgumentException` for bad grade values. The console UI then caught each type separately with a clear message.

### Build verification before every commit
Without being asked, Claude ran `dotnet build` (and `dotnet test` for the test milestone) before each `git commit`. This caught any compilation errors before they reached the commit history.

### Added a useful helper without over-engineering
In `Program.cs`, Claude introduced a `DisplayStudent` local function to avoid copying the same five `Console.WriteLine` calls into both `ViewAllStudents` and `ViewStudentById`. This was the right level of abstraction — one small helper, no new classes or interfaces.

### Tests were properly isolated
Each xUnit test created its own `StudentService` instance, so tests never shared state. The `CreateValidStudent()` helper satisfied all FluentValidation rules, preventing false failures from invalid test data.

---

## Where Correction Was Needed

### Reading existing code needed explicit instruction

Claude did not automatically inspect all existing files at the beginning. It became more accurate only after I specifically instructed it to review the Application layer before making changes. After that, it avoided duplicating existing files such as IStudentService.cs and `StudentValidator.cs`.

### Scope had to be controlled through constraints

When the prompt was broad, Claude sometimes tried to include more than the current milestone required. Clear constraints like “implement only this part” and “do not modify `Program.cs` yet” were needed to keep the work step-by-step and suitable for the practical.

### Program.cs needed refinement after the first version

The first console UI prompt created the menu structure, but the methods were only placeholders. A separate follow-up prompt was needed to fully implement the menu actions and connect them properly with `StudentService`.

---
