using Microsoft.EntityFrameworkCore.Migrations;

namespace ForInterview.Migrations
{
    public partial class Removed_Unused_Properties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "EvaluationId",
                table: "Evaluations");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "Blogs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EvaluationId",
                table: "Evaluations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
