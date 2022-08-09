namespace SmartSchool.Api.Models.DTOs.Responses;

public class StudentSubjectGetDto
{
    public StudentGetDto Student { get; set; }
    public SubjectGetDto Subject { get; set; }
}