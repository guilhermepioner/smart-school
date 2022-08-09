using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.Api.Data.Interfaces;
using SmartSchool.Api.Models;
using SmartSchool.Api.Models.DTOs.Requests;
using SmartSchool.Api.Models.DTOs.Responses;

namespace SmartSchool.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfessorController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;

    public ProfessorController(IMapper mapper, IRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var professorList = await _repository.GetAllProfessorsAsync(includeStudent: true);

            if (!professorList.Any()) return NoContent();
            
            return Ok(_mapper.Map<List<ProfessorGetDto>>(professorList));
        }
        catch (Exception e)
        {
            return BadRequest($"Error {e.Message}");
        }
    }

    [HttpGet("{professorId:int}", Name = "GetByProfessorId")]
    public async Task<IActionResult> GetByProfessorId(int professorId)
    {
        try
        {
            var professor = await _repository.GetProfessorByIdAsync(professorId, includeStudent: true);

            if (professor == null) return NotFound();
            
            return Ok(_mapper.Map<ProfessorGetDto>(professor));
        }
        catch (Exception e)
        {
            return BadRequest($"Error {e.Message}");
        }
    }

    [HttpGet("ByStudent/{studentId:int}")]
    public async Task<IActionResult> GetByStudentId(int studentId)
    {
        try
        {
            var professorList = await _repository.GetProfessorsByStudentIdAsync(studentId, includeStudent: true);
            
            if (!professorList.Any()) return NoContent();
            
            return Ok(_mapper.Map<List<ProfessorGetDto>>(professorList));
        }
        catch (Exception e)
        {
            return BadRequest($"Error {e.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(ProfessorRequestDto model)
    {
        try
        {
            var entry = _mapper.Map<Professor>(model);
            
            _repository.Add(entry);

            if (await _repository.SaveChangesAsync())
            {
                return CreatedAtRoute(nameof(GetByProfessorId), new { professorId = entry.Id }, _mapper.Map<ProfessorGetDto>(entry));
            }
        }
        catch (Exception e)
        {
            return BadRequest($"Error {e.Message}");
        }
        
        return BadRequest();
    }

    [HttpPut("{professorId:int}")]
    public async Task<IActionResult> Put(int professorId, ProfessorRequestDto model)
    {
        try
        {
            var entry = _mapper.Map<Professor>(model);

            var professor = await _repository.GetProfessorByIdAsync(professorId, includeStudent: false);
            if (professor == null) return NotFound();

            entry.Id = professor.Id;
            _repository.Update(entry);
            
            if (await _repository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<ProfessorGetDto>(entry));
            }
        }
        catch (Exception e)
        {
            return BadRequest($"Error {e.Message}");
        }

        return BadRequest();
    }

    [HttpDelete("{professorId:int}")]
    public async Task<IActionResult> Put(int professorId)
    {
        try
        {
            var professor = await _repository.GetProfessorByIdAsync(professorId, includeStudent: false);

            if (professor == null) return NotFound();

            _repository.Delete(professor);
            
            if (await _repository.SaveChangesAsync())
            {
                return Ok("Professor Excluído");
            }
        }
        catch (Exception e)
        {
            return BadRequest($"Error {e.Message}");
        }

        return BadRequest();
    }
}