using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotInstrukcije.API.Migrations
{
    /// <inheritdoc />
    public partial class AddSubjectsToProfessors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Professors_ProfessorId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_ProfessorId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Subjects");

            migrationBuilder.AddColumn<string>(
                name: "Subjects",
                table: "Professors",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subjects",
                table: "Professors");

            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "Subjects",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_ProfessorId",
                table: "Subjects",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Professors_ProfessorId",
                table: "Subjects",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "Id");
        }
    }
}
