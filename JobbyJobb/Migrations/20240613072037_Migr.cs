using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobbyJobb.Migrations
{
    /// <inheritdoc />
    public partial class Migr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dataa",
                table: "Vacancies",
                newName: "Salary");

            migrationBuilder.AddColumn<string>(
                name: "Addres",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EducationLevel",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployerId",
                table: "Vacancies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<float>(
                name: "Experience",
                table: "Vacancies",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Schedule",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sector",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AnonName",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Resumes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpoyeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Schedule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Addres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<float>(type: "real", nullable: false),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Сitizenship = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VacancyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_EmployerId",
                table: "Vacancies",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_EmployeeId",
                table: "Resumes",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_EmpoyeeId",
                table: "Resumes",
                column: "EmpoyeeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ResumeId",
                table: "User",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserId",
                table: "User",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_VacancyId",
                table: "User",
                column: "VacancyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_User_EmployerId",
                table: "Vacancies",
                column: "EmployerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_User_EmployeeId",
                table: "Resumes",
                column: "EmployeeId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_User_EmpoyeeId",
                table: "Resumes",
                column: "EmpoyeeId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_User_EmployerId",
                table: "Vacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_User_EmployeeId",
                table: "Resumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_User_EmpoyeeId",
                table: "Resumes");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Resumes");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_EmployerId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "Addres",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "EducationLevel",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "EmployerId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "Schedule",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "Sector",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "AnonName",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "Vacancies",
                newName: "Dataa");
        }
    }
}
