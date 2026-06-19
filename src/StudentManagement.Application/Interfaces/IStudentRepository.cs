using StudentManagement.Domain.Models;

namespace StudentManagement.Application.Interfaces;

// Defines how student data is stored and retrieved.
// The service layer depends on this interface, not on a concrete storage class.
public interface IStudentRepository
{
    // Saves a new student and assigns its ID.
    void Add(Student student);
    List<Student> GetAll();
    // Returns null if no student with the given ID is found.
    Student? GetById(int id);
    bool ExistsByEmail(string email);
    void Update(Student student);
    void Delete(Student student);
}
