using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtUniversity.Infrastucture.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeyWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    FieldOfStudyAndOrientationId = table.Column<long>(type: "bigint", nullable: false),
                    KeyWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupStudies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessorId = table.Column<long>(type: "bigint", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    Term = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeyWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupStudies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupStudies_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GroupStudies_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DepartMents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartMentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeyWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    GroupStudyId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartMents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartMents_GroupStudies_GroupStudyId",
                        column: x => x.GroupStudyId,
                        principalTable: "GroupStudies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FieldOfStudyAndOrientations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaghtaeReshtehTahsili = table.Column<int>(type: "int", nullable: false),
                    Gerayesh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    KeyWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldOfStudyAndOrientations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldOfStudyAndOrientations_DepartMents_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DepartMents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_FieldOfStudyAndOrientationId",
                table: "Courses",
                column: "FieldOfStudyAndOrientationId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartMents_GroupStudyId",
                table: "DepartMents",
                column: "GroupStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldOfStudyAndOrientations_DepartmentId",
                table: "FieldOfStudyAndOrientations",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupStudies_CourseId",
                table: "GroupStudies",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupStudies_ProfessorId",
                table: "GroupStudies",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_FieldOfStudyAndOrientations_FieldOfStudyAndOrientationId",
                table: "Courses",
                column: "FieldOfStudyAndOrientationId",
                principalTable: "FieldOfStudyAndOrientations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_FieldOfStudyAndOrientations_FieldOfStudyAndOrientationId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "FieldOfStudyAndOrientations");

            migrationBuilder.DropTable(
                name: "DepartMents");

            migrationBuilder.DropTable(
                name: "GroupStudies");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Professors");
        }
    }
}
