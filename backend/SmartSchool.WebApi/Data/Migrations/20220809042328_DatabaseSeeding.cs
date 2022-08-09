using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSchool.Infrastructure.Migrations
{
    public partial class DatabaseSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "alunos",
                columns: new[] { "id", "lastname", "name", "phone" },
                values: new object[,]
                {
                    { 1, "Kent", "Marta", "33225555" },
                    { 2, "Isabela", "Paula", "3354288" },
                    { 3, "Antonia", "Laura", "55668899" },
                    { 4, "Maria", "Luiza", "6565659" },
                    { 5, "Machado", "Lucas", "565685415" },
                    { 6, "Alvares", "Pedro", "456454545" },
                    { 7, "José", "Paulo", "9874512" }
                });

            migrationBuilder.InsertData(
                table: "professores",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Lauro" },
                    { 2, "Roberto" },
                    { 3, "Ronaldo" },
                    { 4, "Rodrigo" },
                    { 5, "Alexandre" }
                });

            migrationBuilder.InsertData(
                table: "disciplinas",
                columns: new[] { "id", "name", "professor_id" },
                values: new object[,]
                {
                    { 1, "Matemática", 1 },
                    { 2, "Física", 2 },
                    { 3, "Português", 3 },
                    { 4, "Inglês", 4 },
                    { 5, "Programação", 5 }
                });

            migrationBuilder.InsertData(
                table: "alunos_disciplinas",
                columns: new[] { "student_id", "subject_id" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 5 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 4, 1 },
                    { 4, 4 },
                    { 4, 5 },
                    { 5, 4 },
                    { 5, 5 },
                    { 6, 1 },
                    { 6, 2 },
                    { 6, 3 },
                    { 6, 4 },
                    { 7, 1 },
                    { 7, 2 },
                    { 7, 3 },
                    { 7, 4 },
                    { 7, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "alunos_disciplinas",
                keyColumns: new[] { "student_id", "subject_id" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "alunos_disciplinas",
                keyColumns: new[] { "student_id", "subject_id" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "alunos_disciplinas",
                keyColumns: new[] { "student_id", "subject_id" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "alunos_disciplinas",
                keyColumns: new[] { "student_id", "subject_id" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "alunos_disciplinas",
                keyColumns: new[] { "student_id", "subject_id" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "alunos_disciplinas",
                keyColumns: new[] { "student_id", "subject_id" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "alunos_disciplinas",
                keyColumns: new[] { "student_id", "subject_id" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "alunos_disciplinas",
                keyColumns: new[] { "student_id", "subject_id" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "alunos_disciplinas",
                keyColumns: new[] { "student_id", "subject_id" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "alunos_disciplinas",
                keyColumns: new[] { "student_id", "subject_id" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "alunos_disciplinas",
                keyColumns: new[] { "student_id", "subject_id" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "alunos_disciplinas",
                keyColumns: new[] { "student_id", "subject_id" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "alunos_disciplinas",
                keyColumns: new[] { "student_id", "subject_id" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "alunos_disciplinas",
                keyColumns: new[] { "student_id", "subject_id" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "alunos_disciplinas",
                keyColumns: new[] { "student_id", "subject_id" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "alunos_disciplinas",
                keyColumns: new[] { "student_id", "subject_id" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "alunos_disciplinas",
                keyColumns: new[] { "student_id", "subject_id" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "alunos_disciplinas",
                keyColumns: new[] { "student_id", "subject_id" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "alunos_disciplinas",
                keyColumns: new[] { "student_id", "subject_id" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "alunos_disciplinas",
                keyColumns: new[] { "student_id", "subject_id" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "alunos_disciplinas",
                keyColumns: new[] { "student_id", "subject_id" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "alunos_disciplinas",
                keyColumns: new[] { "student_id", "subject_id" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "alunos_disciplinas",
                keyColumns: new[] { "student_id", "subject_id" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "alunos",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "alunos",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "alunos",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "alunos",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "alunos",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "alunos",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "alunos",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "disciplinas",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "disciplinas",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "disciplinas",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "disciplinas",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "disciplinas",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "professores",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "professores",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "professores",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "professores",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "professores",
                keyColumn: "id",
                keyValue: 5);
        }
    }
}
