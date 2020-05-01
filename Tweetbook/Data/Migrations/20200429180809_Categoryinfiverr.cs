using Microsoft.EntityFrameworkCore.Migrations;

namespace Tweetbook.Data.Migrations
{
    public partial class Categoryinfiverr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Categories",
                table: "FiverrServices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categories",
                table: "FiverrServices");
        }
    }
}
