using SmartSchool.Api.Models;

namespace SmartSchool.Api.Data.Interfaces;

public interface IRepository
{
    // General
    void Add<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;
    Task<bool> SaveChangesAsync();

    // Student
    Task<List<Student>> GetAllStudentsAsync(bool includeProfessor);        
    Task<List<Student>> GetStudentsBySubjectIdAsync(int subjectId, bool includeSubject);
    Task<Student?> GetStudentByIdAsync(int studentId, bool includeProfessor);
        
    // Professor
    Task<List<Professor>> GetAllProfessorsAsync(bool includeStudent);
    Task<Professor?> GetProfessorByIdAsync(int professorId, bool includeStudent);
    Task<List<Professor>> GetProfessorsByStudentIdAsync(int studentId, bool includeStudent);
}