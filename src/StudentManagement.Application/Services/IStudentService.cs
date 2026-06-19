using StudentManagement.Domain.Models;

namespace StudentManagement.Application.Services;

// Defines the operations the console UI can perform on students.
public interface IStudentService
{
    void Add(Student student);
    List<Student> GetAll();
    Student GetById(int id);
    void UpdateGrade(int id, string grade);
    void Delete(int id);
}
