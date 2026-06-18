using StudentManagement.Domain.Models;

namespace StudentManagement.Application.Services;

public interface IStudentService
{
    void Add(Student student);
    List<Student> GetAll();
    Student GetById(int id);
    void UpdateGrade(int id, string grade);
    void Delete(int id);
}
