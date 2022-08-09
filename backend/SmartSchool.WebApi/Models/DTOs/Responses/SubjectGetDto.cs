namespace SmartSchool.Api.Models.DTOs.Responses;

public class SubjectGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ProfessorGetDto Professor { get; set; }
}