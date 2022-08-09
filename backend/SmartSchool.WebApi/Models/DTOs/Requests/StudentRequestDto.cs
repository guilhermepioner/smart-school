namespace SmartSchool.Api.Models.DTOs.Requests;

public class StudentRequestDto
{
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Phone { get; set; }
    public List<int> SubjectId { get; set; }
}