using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SmartSchool.Infrastructure.Migrations
{
    public partial class InitialScheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "alunos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    lastname = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_alunos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "professores",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_professores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "disciplinas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    professor_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_disciplinas", x => x.id);
                    table.ForeignKey(
                        name: "fk_disciplinas_professores_professor_id",
                        column: x => x.professor_id,
                        principalTable: "professores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "alunos_disciplinas",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "integer", nullable: false),
                    subject_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_alunos_disciplinas", x => new { x.student_id, x.subject_id });
                    table.ForeignKey(
                        name: "fk_alunos_disciplinas_alunos_student_id",
                        column: x => x.student_id,
                        principalTable: "alunos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_alunos_disciplinas_disciplinas_subject_id",
                        column: x => x.subject_id,
                        principalTable: "disciplinas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_alunos_disciplinas_subject_id",
                table: "alunos_disciplinas",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "ix_disciplinas_professor_id",
                table: "disciplinas",
                column: "professor_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alunos_disciplinas");

            migrationBuilder.DropTable(
                name: "alunos");

            migrationBuilder.DropTable(
                name: "disciplinas");

            migrationBuilder.DropTable(
                name: "professores");
        }
    }
}
