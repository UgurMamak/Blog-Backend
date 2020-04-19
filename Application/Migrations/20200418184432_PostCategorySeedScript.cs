using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class PostCategorySeedScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.InsertData(
                table: "PostCategory",
                columns: new[] { "Id", "CategoryId", "Created", "CreatedBy", "IsActive", "IsDeleted", "PostId", "Updated", "UpdatedBy" },
                values: new object[] { "b52cdbc5-5ec8-4b82-a034-619f3cb6ea3d", "6ab2c130-b07f-4d76-86dd-d9f1d89fac81", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), false, false, "d1013284-4e87-47c6-b28f-47ece4ba9888", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "PostCategory",
                columns: new[] { "Id", "CategoryId", "Created", "CreatedBy", "IsActive", "IsDeleted", "PostId", "Updated", "UpdatedBy" },
                values: new object[] { "6f628d5f-70f4-4525-8327-e17817b72421", "68a8cbe3-847f-4cb9-9f40-f89dabaa308c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), false, false, "34bb076e-36ca-4f6b-bb78-7949daeef2b1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PostCategory",
                keyColumn: "Id",
                keyValue: "6f628d5f-70f4-4525-8327-e17817b72421");

            migrationBuilder.DeleteData(
                table: "PostCategory",
                keyColumn: "Id",
                keyValue: "b52cdbc5-5ec8-4b82-a034-619f3cb6ea3d");        
        }
    }
}
