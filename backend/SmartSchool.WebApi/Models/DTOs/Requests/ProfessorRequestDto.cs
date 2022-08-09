namespace SmartSchool.Api.Models.DTOs.Requests;

public class ProfessorRequestDto
{
    public string Name { get; set; }
    public List<int> SubjectId { get; set; }
}