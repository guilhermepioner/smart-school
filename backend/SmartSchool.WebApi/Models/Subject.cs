namespace SmartSchool.Api.Models;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ProfessorId { get; set; }
    public Professor Professor { get; set; }
    public IEnumerable<StudentSubject> SubjectStudents { get; set; }
}