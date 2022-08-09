namespace SmartSchool.Api.Models;

public class Professor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Subject> Subjects { get; set; }
}