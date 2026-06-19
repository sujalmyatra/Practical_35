using StudentManagement.Domain.Models;

namespace StudentManagement.Application.Interfaces;

public interface IStudentRepository
{
    void Add(Student student);
    List<Student> GetAll();
    Student? GetById(int id);
    bool ExistsByEmail(string email);
    void Update(Student student);
    void Delete(Student student);
}
