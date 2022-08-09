namespace SmartSchool.Api.Models.DTOs.Responses;

public class ProfessorGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<SubjectGetDto> Subjects { get; set; }
}