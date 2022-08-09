using AutoMapper;
using SmartSchool.Api.Models.DTOs.Requests;
using SmartSchool.Api.Models.DTOs.Responses;

namespace SmartSchool.Api.Models.Profiles;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        // Student
        CreateMap<Student, StudentGetDto>().ReverseMap();
        CreateMap<Student, StudentRequestDto>().ReverseMap();
        
        // Professor
        CreateMap<Professor, ProfessorGetDto>().ReverseMap();
        CreateMap<Professor, ProfessorRequestDto>().ReverseMap();
        
        // Subject
        CreateMap<Subject, SubjectGetDto>().ReverseMap();

        // StudentSubject
        CreateMap<StudentSubject, StudentSubjectGetDto>().ReverseMap();
    }
}