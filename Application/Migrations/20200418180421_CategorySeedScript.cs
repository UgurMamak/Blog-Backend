using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class CategorySeedScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName", "Created", "CreatedBy", "IsActive", "IsDeleted", "Updated", "UpdatedBy" },
                values: new object[] { "b122e19b-53a5-4adb-a6c7-b4427da061e5", "Kozmetik", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName", "Created", "CreatedBy", "IsActive", "IsDeleted", "Updated", "UpdatedBy" },
                values: new object[] { "6ab2c130-b07f-4d76-86dd-d9f1d89fac81", "Teknoloji", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName", "Created", "CreatedBy", "IsActive", "IsDeleted", "Updated", "UpdatedBy" },
                values: new object[] { "68a8cbe3-847f-4cb9-9f40-f89dabaa308c", "Spor", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "68a8cbe3-847f-4cb9-9f40-f89dabaa308c");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "6ab2c130-b07f-4d76-86dd-d9f1d89fac81");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "b122e19b-53a5-4adb-a6c7-b4427da061e5");

        }
    }
}
