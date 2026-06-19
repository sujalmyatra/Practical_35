namespace StudentManagement.Domain.Models;

// Represents a student in the system.
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime EnrollmentDate { get; set; }
    public string Grade { get; set; } = string.Empty;
}
