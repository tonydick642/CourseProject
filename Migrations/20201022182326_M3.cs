using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseProject.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonName",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "LessonTuition",
                table: "Lessons");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Swimmers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SwimmerPhone",
                table: "Swimmers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Swimmers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dateOfBirth",
                table: "Swimmers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Report",
                table: "ProgressReports",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Tuition",
                table: "Lessons",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Coachs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Admins",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Swimmers_UserId",
                table: "Swimmers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Coachs_UserId",
                table: "Coachs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserId",
                table: "Admins",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_AspNetUsers_UserId",
                table: "Admins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Coachs_AspNetUsers_UserId",
                table: "Coachs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Swimmers_AspNetUsers_UserId",
                table: "Swimmers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_AspNetUsers_UserId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Coachs_AspNetUsers_UserId",
                table: "Coachs");

            migrationBuilder.DropForeignKey(
                name: "FK_Swimmers_AspNetUsers_UserId",
                table: "Swimmers");

            migrationBuilder.DropIndex(
                name: "IX_Swimmers_UserId",
                table: "Swimmers");

            migrationBuilder.DropIndex(
                name: "IX_Coachs_UserId",
                table: "Coachs");

            migrationBuilder.DropIndex(
                name: "IX_Admins_UserId",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Swimmers");

            migrationBuilder.DropColumn(
                name: "SwimmerPhone",
                table: "Swimmers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Swimmers");

            migrationBuilder.DropColumn(
                name: "dateOfBirth",
                table: "Swimmers");

            migrationBuilder.DropColumn(
                name: "Report",
                table: "ProgressReports");

            migrationBuilder.DropColumn(
                name: "Tuition",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Coachs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Admins");

            migrationBuilder.AddColumn<string>(
                name: "LessonName",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LessonTuition",
                table: "Lessons",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
