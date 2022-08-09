using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Api.Data.Context;
using SmartSchool.Api.Data.Interfaces;
using SmartSchool.Api.Models;

namespace SmartSchool.Api.Data.Repositories;

public class Repository : IRepository
{
    private readonly DatabaseContext _context;

    public Repository(DatabaseContext context)
    {
        _context = context;
    }

    public void Add<T>(T entity) where T : class
    {
        _context.Add(entity);
    }

    public void Update<T>(T entity) where T : class
    {
        _context.Update(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
        _context.Remove(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync()) > 0;
    }

    public async Task<List<Student>> GetAllStudentsAsync(bool includeDisciplina = false)
    {
        IQueryable<Student> query = _context.Alunos;

        if (includeDisciplina)
        {
            query = query.Include(student => student.Subjects)
                .ThenInclude(studentSubject=> studentSubject.Subject)
                .ThenInclude(subject => subject.Professor);
        }

        query = query.AsNoTracking()
            .OrderBy(subject => subject.Id);

        return await query.ToListAsync();
    }

    public async Task<Student?> GetStudentByIdAsync(int studentId, bool includeDisciplina)
    {
        IQueryable<Student> query = _context.Alunos;

        if (includeDisciplina)
        {
            query = query.Include(student => student.Subjects)
                .ThenInclude(studentSubject=> studentSubject.Subject)
                .ThenInclude(subject => subject.Professor);
        }

        query = query.AsNoTracking()
            .OrderBy(student => student.Id)
            .Where(student => student.Id == studentId);

        return await query.FirstOrDefaultAsync();
    }

    public async Task<List<Student>> GetStudentsBySubjectIdAsync(int subjectId, bool includeSubject)
    {
        IQueryable<Student> query = _context.Alunos;

        if (includeSubject)
        {
            query = query.Include(student => student.Subjects)
                .ThenInclude(studentSubject=> studentSubject.Subject)
                .ThenInclude(subject => subject.Professor);
        }

        query = query.AsNoTracking()
            .OrderBy(aluno => aluno.Id)
            .Where(aluno => aluno.Subjects.Any(studentSubject=> studentSubject.SubjectId == subjectId));

        return await query.ToListAsync();
    }

    public async Task<List<Professor>> GetProfessorsByStudentIdAsync(int studentId, bool includeStudent)
    {
        IQueryable<Professor> query = _context.Professores;

        if (includeStudent)
        {
            query = query.Include(professor => professor.Subjects);
        }

        query = query.AsNoTracking()
            .OrderBy(professor => professor.Id)
            .Where(professor => professor.Subjects.Any(s =>
                s.SubjectStudents.Any(studentSubject=> studentSubject.StudentId == studentId)));

        return await query.ToListAsync();
    }

    public async Task<List<Professor>> GetAllProfessorsAsync(bool includeStudent = true)
    {
        IQueryable<Professor> query = _context.Professores;

        if (includeStudent)
        {
            query = query.Include(professor => professor.Subjects);
        }

        query = query.AsNoTracking()
            .OrderBy(professor => professor.Id);

        return await query.ToListAsync();
    }

    public async Task<Professor> GetProfessorByIdAsync(int professorId, bool includeStudent = true)
    {
        IQueryable<Professor> query = _context.Professores;

        if (includeStudent)
        {
            query = query.Include(professor => professor.Subjects);
        }

        query = query.AsNoTracking()
            .OrderBy(professor => professor.Id)
            .Where(professor => professor.Id == professorId);

        return await query.FirstOrDefaultAsync();
    }
}