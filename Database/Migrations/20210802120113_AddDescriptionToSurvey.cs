using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyApp.Database.Migrations
{
    public partial class AddDescriptionToSurvey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Surveys",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Surveys");
        }
    }
}
