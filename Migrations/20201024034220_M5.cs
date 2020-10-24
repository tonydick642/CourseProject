using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseProject.Migrations
{
    public partial class M5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Report",
                table: "Enrollments");

            migrationBuilder.AddColumn<string>(
                name: "ProgressReport",
                table: "Enrollments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProgressReport",
                table: "Enrollments");

            migrationBuilder.AddColumn<string>(
                name: "Report",
                table: "Enrollments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
