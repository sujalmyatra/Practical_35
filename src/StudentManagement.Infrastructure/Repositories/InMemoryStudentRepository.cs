using StudentManagement.Application.Interfaces;
using StudentManagement.Domain.Models;

namespace StudentManagement.Infrastructure.Repositories;

public class InMemoryStudentRepository : IStudentRepository
{
    private readonly List<Student> _students = new();
    private int _nextId = 1;

    public void Add(Student student)
    {
        student.Id = _nextId++;
        _students.Add(student);
    }

    public List<Student> GetAll() => _students.ToList();

    public Student? GetById(int id) => _students.FirstOrDefault(s => s.Id == id);

    public bool ExistsByEmail(string email) =>
        _students.Any(s => s.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

    public void Update(Student student) { }

    public void Delete(Student student) => _students.Remove(student);
}
