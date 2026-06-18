using FluentValidation;
using StudentManagement.Application.Validators;
using StudentManagement.Domain.Models;

namespace StudentManagement.Application.Services;

public class StudentService : IStudentService
{
    private readonly List<Student> _students = new();
    private readonly StudentValidator _validator = new();
    private int _nextId = 1;

    private static readonly string[] ValidGrades = { "A", "B", "C", "D", "F" };

    public void Add(Student student)
    {
        var result = _validator.Validate(student);
        if (!result.IsValid)
            throw new ValidationException(result.Errors);

        if (_students.Any(s => s.Email.Equals(student.Email, StringComparison.OrdinalIgnoreCase)))
            throw new InvalidOperationException($"A student with email '{student.Email}' already exists.");

        student.Id = _nextId++;
        _students.Add(student);
    }

    public List<Student> GetAll()
    {
        return _students.ToList();
    }

    public Student GetById(int id)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        if (student is null)
            throw new KeyNotFoundException($"Student with ID {id} was not found.");

        return student;
    }

    public void UpdateGrade(int id, string grade)
    {
        if (string.IsNullOrWhiteSpace(grade))
            throw new ArgumentException("Grade is required.", nameof(grade));

        if (!ValidGrades.Contains(grade))
            throw new ArgumentException($"Grade must be one of: {string.Join(", ", ValidGrades)}.", nameof(grade));

        var student = GetById(id);
        student.Grade = grade;
    }

    public void Delete(int id)
    {
        var student = GetById(id);
        _students.Remove(student);
    }
}
