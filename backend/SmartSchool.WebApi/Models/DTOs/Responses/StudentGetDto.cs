namespace SmartSchool.Api.Models.DTOs.Responses;

public class StudentGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Phone { get; set; }
    public List<StudentSubjectGetDto> Subjects { get; set; }
}