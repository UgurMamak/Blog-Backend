using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class UserUpdateScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "0f3ee85a-ba22-408d-8898-0369fb4acf1a");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "7275eae4-48d0-49f6-9d9b-dc21f7c21c56");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "bbc13e8b-e82d-444e-9024-72f276ea1bfd");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "4263f6b4-368d-4104-b149-5a984fff4be0");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "449de1a9-fd34-48f2-b730-abb7f2110fe4");

            migrationBuilder.AddColumn<string>(
                name: "ImgName",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgName",
                table: "User");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName", "Created", "CreatedBy", "IsActive", "IsDeleted", "Updated", "UpdatedBy" },
                values: new object[,]
                {
                    { "0f3ee85a-ba22-408d-8898-0369fb4acf1a", "Kozmetik", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") },
                    { "bbc13e8b-e82d-444e-9024-72f276ea1bfd", "Teknoloji", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") },
                    { "7275eae4-48d0-49f6-9d9b-dc21f7c21c56", "Spor", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Created", "CreatedBy", "Email", "FirstName", "IsActive", "IsDeleted", "LastName", "PasswordHash", "PasswordSalt", "Status", "Updated", "UpdatedBy" },
                values: new object[,]
                {
                    { "449de1a9-fd34-48f2-b730-abb7f2110fe4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "ugurmamak98@gmail.com", null, false, false, null, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") },
                    { "4263f6b4-368d-4104-b149-5a984fff4be0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "mehmeteren@gmail.com", null, false, false, null, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") }
                });
        }
    }
}
