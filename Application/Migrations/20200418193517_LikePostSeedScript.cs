using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class LikePostSeedScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LikePost",
                keyColumn: "Id",
                keyValue: "d4d2130f-6b23-47c9-8458-af76977f0a79");

            migrationBuilder.InsertData(
                table: "LikePost",
                columns: new[] { "Id", "Created", "CreatedBy", "IsActive", "IsDeleted", "LikeStatus", "PostId", "Updated", "UpdatedBy", "UserId" },
                values: new object[] { "2e5573bb-0a06-439a-a7c6-a387d3940d9e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), false, false, false, "34bb076e-36ca-4f6b-bb78-7949daeef2b1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "6a818bb9-8bd3-421a-8fd8-7c0d18df8094" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LikePost",
                keyColumn: "Id",
                keyValue: "2e5573bb-0a06-439a-a7c6-a387d3940d9e");

            migrationBuilder.InsertData(
                table: "LikePost",
                columns: new[] { "Id", "Created", "CreatedBy", "IsActive", "IsDeleted", "LikeStatus", "PostId", "Updated", "UpdatedBy", "UserId" },
                values: new object[] { "d4d2130f-6b23-47c9-8458-af76977f0a79", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), false, false, false, "374aef84-52f9-4873-855d-6ab420ba675e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "6a818bb9-8bd3-421a-8fd8-7c0d18df8094" });
        }
    }
}
