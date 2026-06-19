using StudentManagement.Application.Interfaces;
using StudentManagement.Domain.Models;

namespace StudentManagement.Infrastructure.Repositories;

// Stores students in a plain List<Student>. Data is lost when the app closes.
public class InMemoryStudentRepository : IStudentRepository
{
    private readonly List<Student> _students = new();
    private int _nextId = 1;

    public void Add(Student student)
    {
        // Assign a unique ID before saving.
        student.Id = _nextId++;
        _students.Add(student);
    }

    // Returns a copy of the list to prevent the caller from modifying internal state directly.
    public List<Student> GetAll() => _students.ToList();

    // Returns null when not found — the service layer converts this into a KeyNotFoundException.
    public Student? GetById(int id) => _students.FirstOrDefault(s => s.Id == id);

    public bool ExistsByEmail(string email) =>
        _students.Any(s => s.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

    // No action needed for in-memory storage — Student is a reference type, so any
    // property change made by the service is already reflected in the stored object.
    public void Update(Student student) { }

    public void Delete(Student student) => _students.Remove(student);
}
