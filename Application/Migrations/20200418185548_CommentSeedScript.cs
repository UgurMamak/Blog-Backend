using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class CommentSeedScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "ConfirmStatus", "Content", "Created", "CreatedBy", "IsActive", "IsDeleted", "LikeStatus", "PostId", "Updated", "UpdatedBy", "UserId" },
                values: new object[] { "8e14edc4-1731-47d1-b383-542095a69f01", true, "5g teknolojisi ile ilgili en iyi makale olmuş", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), false, false, false, "34bb076e-36ca-4f6b-bb78-7949daeef2b1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "eba5f437-e5ed-4d74-a68b-3303af51a7d5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: "8e14edc4-1731-47d1-b383-542095a69f01");

            
        }
    }
}
