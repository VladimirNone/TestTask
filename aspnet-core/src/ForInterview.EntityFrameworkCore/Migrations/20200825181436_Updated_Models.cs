using Microsoft.EntityFrameworkCore.Migrations;

namespace ForInterview.Migrations
{
    public partial class Updated_Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Posts",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Evaluations",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Posts");

            migrationBuilder.AlterColumn<byte>(
                name: "Value",
                table: "Evaluations",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
