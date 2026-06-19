using FluentValidation;
using StudentManagement.Application.Services;
using StudentManagement.Application.Validators;
using StudentManagement.Domain.Models;
using StudentManagement.Infrastructure.Repositories;

// Wire up dependencies manually — no DI container is used in this console app.
IValidator<Student> validator = new StudentValidator();
var repository = new InMemoryStudentRepository();
var service = new StudentService(repository, validator);
bool running = true;

while (running)
{
    Console.WriteLine("\n=== Student Management System ===");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. View All Students");
    Console.WriteLine("3. View Student By Id");
    Console.WriteLine("4. Update Student Grade");
    Console.WriteLine("5. Delete Student");
    Console.WriteLine("6. Exit");
    Console.Write("\nChoose an option: ");

    string? input = Console.ReadLine();

    switch (input)
    {
        case "1": AddStudent(); break;
        case "2": ViewAllStudents(); break;
        case "3": ViewStudentById(); break;
        case "4": UpdateStudentGrade(); break;
        case "5": DeleteStudent(); break;
        case "6": running = false; break;
        default: Console.WriteLine("Invalid option. Please try again."); break;
    }
}

Console.WriteLine("\nGoodbye!");

void AddStudent()
{
    Console.WriteLine("\n-- Add Student --");

    Console.Write("Name: ");
    string name = Console.ReadLine()?.Trim() ?? string.Empty;

    Console.Write("Email: ");
    string email = Console.ReadLine()?.Trim() ?? string.Empty;

    Console.Write("Enrollment Date (yyyy-MM-dd): ");
    string dateInput = Console.ReadLine()?.Trim() ?? string.Empty;
    if (!DateTime.TryParse(dateInput, out DateTime enrollmentDate))
    {
        Console.WriteLine("Invalid date format.");
        return;
    }

    Console.Write("Grade (A, B, C, D, F): ");
    string grade = Console.ReadLine()?.Trim() ?? string.Empty;

    var student = new Student
    {
        Name = name,
        Email = email,
        EnrollmentDate = enrollmentDate,
        Grade = grade
    };

    try
    {
        service.Add(student);
        Console.WriteLine($"Student added successfully with ID {student.Id}.");
    }
    catch (ValidationException ex)
    {
        Console.WriteLine("Validation errors:");
        foreach (var error in ex.Errors)
            Console.WriteLine($"  - {error.ErrorMessage}");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

void ViewAllStudents()
{
    Console.WriteLine("\n-- All Students --");

    var students = service.GetAll();

    if (students.Count == 0)
    {
        Console.WriteLine("No students found.");
        return;
    }

    foreach (var student in students)
        DisplayStudent(student);
}

void ViewStudentById()
{
    Console.WriteLine("\n-- View Student By Id --");

    Console.Write("Enter Student ID: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("Invalid ID.");
        return;
    }

    try
    {
        var student = service.GetById(id);
        DisplayStudent(student);
    }
    catch (KeyNotFoundException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

void UpdateStudentGrade()
{
    Console.WriteLine("\n-- Update Student Grade --");

    Console.Write("Enter Student ID: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("Invalid ID.");
        return;
    }

    Console.Write("New Grade (A, B, C, D, F): ");
    string grade = Console.ReadLine()?.Trim() ?? string.Empty;

    try
    {
        service.UpdateGrade(id, grade);
        Console.WriteLine("Grade updated successfully.");
    }
    catch (KeyNotFoundException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

void DeleteStudent()
{
    Console.WriteLine("\n-- Delete Student --");

    Console.Write("Enter Student ID: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("Invalid ID.");
        return;
    }

    try
    {
        service.Delete(id);
        Console.WriteLine("Student deleted successfully.");
    }
    catch (KeyNotFoundException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

// Prints a single student's details to the console in a consistent format.
void DisplayStudent(Student student)
{
    Console.WriteLine($"\n  ID            : {student.Id}");
    Console.WriteLine($"  Name          : {student.Name}");
    Console.WriteLine($"  Email         : {student.Email}");
    Console.WriteLine($"  Enrollment Date: {student.EnrollmentDate:yyyy-MM-dd}");
    Console.WriteLine($"  Grade         : {student.Grade}");
}