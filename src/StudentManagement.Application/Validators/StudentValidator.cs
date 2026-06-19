using FluentValidation;
using StudentManagement.Domain.Models;

namespace StudentManagement.Application.Validators;

// Validates a Student object before it is added to storage.
public class StudentValidator : AbstractValidator<Student>
{
    // Accepted letter grades — must stay in sync with ValidGrades in StudentService.
    private static readonly string[] ValidGrades = { "A", "B", "C", "D", "F" };

    public StudentValidator()
    {
        RuleFor(s => s.Name)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(s => s.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email must be a valid email address.");

        RuleFor(s => s.Grade)
            .NotEmpty().WithMessage("Grade is required.")
            .Must(g => ValidGrades.Contains(g))
            .WithMessage("Grade must be one of: A, B, C, D, F.");

        RuleFor(s => s.EnrollmentDate)
            .NotEmpty().WithMessage("Enrollment date is required.")
            .LessThanOrEqualTo(DateTime.Today).WithMessage("Enrollment date cannot be in the future.");
    }
}
