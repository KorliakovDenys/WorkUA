using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkUA.Migrations
{
    /// <inheritdoc />
    public partial class ApplicantExperienceAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Experience",
                table: "Applicant",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Applicant");
        }
    }
}
