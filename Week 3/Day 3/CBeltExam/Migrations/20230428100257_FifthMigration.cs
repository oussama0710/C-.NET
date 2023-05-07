using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBeltExam.Migrations
{
    public partial class FifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Reward",
                table: "Quests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Reward",
                table: "Quests",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
