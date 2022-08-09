using Microsoft.EntityFrameworkCore;
using SmartSchool.Api.Models;

namespace SmartSchool.Api.Data.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) :
        base(options)
    {
    }

    public DbSet<Student> Alunos { get; set; } = null!;
    public DbSet<Professor> Professores { get; set; } = null!;
    public DbSet<Subject> Disciplinas { get; set; } = null!;
    public DbSet<StudentSubject> AlunosDisciplinas { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<StudentSubject>().HasKey(ss => new {ss.StudentId, ss.SubjectId});

        builder.Entity<Professor>()
            .HasData(new List<Professor>()
            {
                new () {Id = 1, Name = "Lauro" },
                new () {Id = 2, Name = "Roberto" },
                new () {Id = 3, Name = "Ronaldo" },
                new () {Id = 4, Name = "Rodrigo" },
                new () {Id = 5, Name = "Alexandre" }
            });
        
        builder.Entity<Student>()
            .HasData(new List<Student>()
            {
                new () { Id = 1, Name = "Marta", Lastname = "Kent", Phone = "33225555" },
                new () { Id = 2, Name = "Paula", Lastname = "Isabela", Phone = "3354288" },
                new () { Id = 3, Name = "Laura", Lastname = "Antonia", Phone = "55668899" },
                new () { Id = 4, Name = "Luiza", Lastname = "Maria", Phone = "6565659" },
                new () { Id = 5, Name = "Lucas", Lastname = "Machado", Phone = "565685415" },
                new () { Id = 6, Name = "Pedro", Lastname = "Alvares", Phone = "456454545" },
                new () { Id = 7, Name = "Paulo", Lastname = "José", Phone = "9874512" }
            });
        
        builder.Entity<Subject>()
            .HasData(new List<Subject>()
            {
                new () { Id = 1, Name = "Matemática", ProfessorId = 1},
                new () { Id = 2, Name = "Física", ProfessorId = 2},
                new () { Id = 3, Name = "Português", ProfessorId = 3},
                new () { Id = 4, Name = "Inglês", ProfessorId = 4},
                new () { Id = 5, Name = "Programação", ProfessorId = 5}
            });
        
        builder.Entity<StudentSubject>()
            .HasData(new List<StudentSubject>()
            {
                new () { StudentId = 1, SubjectId = 2 },
                new () { StudentId = 1, SubjectId = 4 },
                new () { StudentId = 1, SubjectId = 5 },
                new () { StudentId = 2, SubjectId = 1 },
                new () { StudentId = 2, SubjectId = 2 },
                new () { StudentId = 2, SubjectId = 5 },
                new () { StudentId = 3, SubjectId = 1 },
                new () { StudentId = 3, SubjectId = 2 },
                new () { StudentId = 3, SubjectId = 3 },
                new () { StudentId = 4, SubjectId = 1 },
                new () { StudentId = 4, SubjectId = 4 },
                new () { StudentId = 4, SubjectId = 5 },
                new () { StudentId = 5, SubjectId = 4 },
                new () { StudentId = 5, SubjectId = 5 },
                new () { StudentId = 6, SubjectId = 1 },
                new () { StudentId = 6, SubjectId = 2 },
                new () { StudentId = 6, SubjectId = 3 },
                new () { StudentId = 6, SubjectId = 4 },
                new () { StudentId = 7, SubjectId = 1 },
                new () { StudentId = 7, SubjectId = 2 },
                new () { StudentId = 7, SubjectId = 3 },
                new () { StudentId = 7, SubjectId = 4 },
                new () { StudentId = 7, SubjectId = 5 }
            });
    }
}