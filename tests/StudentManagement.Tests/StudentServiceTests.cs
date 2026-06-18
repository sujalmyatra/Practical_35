using StudentManagement.Application.Services;
using StudentManagement.Domain.Models;

namespace StudentManagement.Tests;

public class StudentServiceTests
{
    private static Student CreateValidStudent() => new Student
    {
        Name = "John Doe",
        Email = "john.doe@example.com",
        EnrollmentDate = new DateTime(2024, 1, 1),
        Grade = "A"
    };

    [Fact]
    public void Add_ShouldAddStudentSuccessfully()
    {
        // Arrange
        var service = new StudentService();
        var student = CreateValidStudent();

        // Act
        service.Add(student);

        // Assert
        var students = service.GetAll();
        Assert.Single(students);
        Assert.Equal("John Doe", students[0].Name);
    }

    [Fact]
    public void GetAll_ShouldReturnAllStudents()
    {
        // Arrange
        var service = new StudentService();
        service.Add(CreateValidStudent());
        service.Add(new Student
        {
            Name = "Jane Smith",
            Email = "jane.smith@example.com",
            EnrollmentDate = new DateTime(2024, 1, 1),
            Grade = "B"
        });

        // Act
        var students = service.GetAll();

        // Assert
        Assert.Equal(2, students.Count);
    }

    [Fact]
    public void GetById_ShouldReturnCorrectStudent()
    {
        // Arrange
        var service = new StudentService();
        var student = CreateValidStudent();
        service.Add(student);

        // Act
        var result = service.GetById(student.Id);

        // Assert
        Assert.Equal(student.Id, result.Id);
        Assert.Equal("John Doe", result.Name);
    }

    [Fact]
    public void UpdateGrade_ShouldUpdateStudentGrade()
    {
        // Arrange
        var service = new StudentService();
        var student = CreateValidStudent();
        service.Add(student);

        // Act
        service.UpdateGrade(student.Id, "B");

        // Assert
        var updated = service.GetById(student.Id);
        Assert.Equal("B", updated.Grade);
    }

    [Fact]
    public void Delete_ShouldRemoveStudent()
    {
        // Arrange
        var service = new StudentService();
        var student = CreateValidStudent();
        service.Add(student);

        // Act
        service.Delete(student.Id);

        // Assert
        Assert.Empty(service.GetAll());
    }
}
