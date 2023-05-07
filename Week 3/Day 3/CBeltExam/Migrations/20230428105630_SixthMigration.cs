using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBeltExam.Migrations
{
    public partial class SixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsJoined",
                table: "Missions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsJoined",
                table: "Missions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
