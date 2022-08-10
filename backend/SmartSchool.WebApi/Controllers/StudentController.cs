using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.Api.Data.Interfaces;
using SmartSchool.Api.Models;
using SmartSchool.Api.Models.DTOs.Requests;
using SmartSchool.Api.Models.DTOs.Responses;

namespace SmartSchool.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;

    public StudentController(IMapper mapper, IRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var studentList = await _repository.GetAllStudentsAsync(includeProfessor: true);

            if (!studentList.Any()) return NoContent();
            
            return Ok(_mapper.Map<List<StudentGetDto>>(studentList));
        }
        catch (Exception e)
        {
            return BadRequest($"Error {e.Message}");
        }
    }

    [HttpGet("{studentId:int}", Name = "GetByStudentId")]
    public async Task<IActionResult> GetByStudentId(int studentId)
    {
        try
        {
            var student = await _repository.GetStudentByIdAsync(studentId, includeProfessor: true);

            if (student == null) return NotFound();
            
            return Ok(_mapper.Map<StudentGetDto>(student));
        }
        catch (Exception e)
        {
            return BadRequest($"Error {e.Message}");
        }
    }

    [HttpGet("BySubject/{subjectId:int}")]
    public async Task<IActionResult> GetBySubjectId(int subjectId)
    {
        try
        {
            var studentList = await _repository.GetStudentsBySubjectIdAsync(subjectId, includeSubject: true);
            
            if (!studentList.Any()) return NoContent();
            
            return Ok(_mapper.Map<List<StudentGetDto>>(studentList));
        }
        catch (Exception e)
        {
            return BadRequest($"Error {e.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(StudentRequestDto model)
    {
        try
        {
            var entry = _mapper.Map<Student>(model);
            
            _repository.Add(entry);

            if (await _repository.SaveChangesAsync())
            {
                return CreatedAtRoute(nameof(GetByStudentId), new { studentId = entry.Id }, _mapper.Map<StudentGetDto>(entry));
            }
        }
        catch (Exception e)
        {
            return BadRequest($"Error {e.Message}");
        }
        
        return BadRequest();
    }

    [HttpPut("{studentId:int}")]
    public async Task<IActionResult> Put(int studentId, StudentRequestDto model)
    {
        try
        {
            var entry = _mapper.Map<Student>(model);
            
            var student = await _repository.GetStudentByIdAsync(studentId, includeProfessor: false);
            if (student == null) return NotFound();

            entry.Id = student.Id;
            _repository.Update(entry);
            
            if (await _repository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<StudentGetDto>(entry));
            }
        }
        catch (Exception e)
        {
            return BadRequest($"Error {e.Message}");
        }

        return BadRequest();
    }
    
    [HttpDelete("{studentId:int}")]
    public async Task<IActionResult> Put(int studentId)
    {
        try
        {
            var student = await _repository.GetStudentByIdAsync(studentId, includeProfessor: false);

            if (student == null) return NotFound();

            _repository.Delete(student);
            
            if (await _repository.SaveChangesAsync())
            {
                return Ok(new { Message = "Estudante Excluído" } );
            }
        }
        catch (Exception e)
        {
            return BadRequest($"Error {e.Message}");
        }

        return BadRequest();
    }
}