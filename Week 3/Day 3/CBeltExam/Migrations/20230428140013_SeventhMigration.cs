using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBeltExam.Migrations
{
    public partial class SeventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PeopleOnQuest",
                table: "Quests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeopleOnQuest",
                table: "Quests");
        }
    }
}
