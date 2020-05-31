using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class UserUpdateScript2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FacebookLink",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramLink",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterLink",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookLink",
                table: "User");

            migrationBuilder.DropColumn(
                name: "InstagramLink",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TwitterLink",
                table: "User");
        }
    }
}
