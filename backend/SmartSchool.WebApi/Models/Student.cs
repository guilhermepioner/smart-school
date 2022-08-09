namespace SmartSchool.Api.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Phone { get; set; }
    public IEnumerable<StudentSubject> Subjects { get; set; }
}