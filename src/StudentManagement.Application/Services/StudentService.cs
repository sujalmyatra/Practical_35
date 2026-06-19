using FluentValidation;
using StudentManagement.Application.Interfaces;
using StudentManagement.Domain.Models;

namespace StudentManagement.Application.Services;

// Contains the business rules for managing students.
// Storage and validation are injected so this class only focuses on logic.
public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;
    private readonly IValidator<Student> _validator;

    // Accepted grades for UpdateGrade — must stay in sync with ValidGrades in StudentValidator.
    private static readonly string[] ValidGrades = { "A", "B", "C", "D", "F" };

    public StudentService(IStudentRepository repository, IValidator<Student> validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public void Add(Student student)
    {
        var result = _validator.Validate(student);
        if (!result.IsValid)
            throw new ValidationException(result.Errors);

        if (_repository.ExistsByEmail(student.Email))
            throw new InvalidOperationException($"A student with email '{student.Email}' already exists.");

        _repository.Add(student);
    }

    public List<Student> GetAll() => _repository.GetAll();

    public Student GetById(int id)
    {
        var student = _repository.GetById(id);
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
        _repository.Update(student);
    }

    public void Delete(int id)
    {
        var student = GetById(id);
        _repository.Delete(student);
    }
}
