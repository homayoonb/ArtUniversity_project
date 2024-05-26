using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtUniversity.Infrastucture.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FieldOfStudyAndOrientations_DepartMents_DepartmentId",
                table: "FieldOfStudyAndOrientations");

            migrationBuilder.DropIndex(
                name: "IX_FieldOfStudyAndOrientations_DepartmentId",
                table: "FieldOfStudyAndOrientations");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "FieldOfStudyAndOrientations");

            migrationBuilder.AddColumn<long>(
                name: "FieldOfStudyAndOrientationId",
                table: "DepartMents",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_DepartMents_FieldOfStudyAndOrientationId",
                table: "DepartMents",
                column: "FieldOfStudyAndOrientationId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartMents_FieldOfStudyAndOrientations_FieldOfStudyAndOrientationId",
                table: "DepartMents",
                column: "FieldOfStudyAndOrientationId",
                principalTable: "FieldOfStudyAndOrientations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartMents_FieldOfStudyAndOrientations_FieldOfStudyAndOrientationId",
                table: "DepartMents");

            migrationBuilder.DropIndex(
                name: "IX_DepartMents_FieldOfStudyAndOrientationId",
                table: "DepartMents");

            migrationBuilder.DropColumn(
                name: "FieldOfStudyAndOrientationId",
                table: "DepartMents");

            migrationBuilder.AddColumn<long>(
                name: "DepartmentId",
                table: "FieldOfStudyAndOrientations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_FieldOfStudyAndOrientations_DepartmentId",
                table: "FieldOfStudyAndOrientations",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_FieldOfStudyAndOrientations_DepartMents_DepartmentId",
                table: "FieldOfStudyAndOrientations",
                column: "DepartmentId",
                principalTable: "DepartMents",
                principalColumn: "Id");
        }
    }
}
