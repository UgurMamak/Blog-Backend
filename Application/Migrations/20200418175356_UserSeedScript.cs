using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class UserSeedScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {           
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Created", "CreatedBy", "Email", "IsActive", "IsDeleted", "Updated", "UpdatedBy" },
                values: new object[] { "eba5f437-e5ed-4d74-a68b-3303af51a7d5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "ugurmamak98@gmail.com", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Created", "CreatedBy", "Email", "IsActive", "IsDeleted", "Updated", "UpdatedBy" },
                values: new object[] { "6a818bb9-8bd3-421a-8fd8-7c0d18df8094", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "mehmeteren@gmail.com", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "6a818bb9-8bd3-421a-8fd8-7c0d18df8094");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "eba5f437-e5ed-4d74-a68b-3303af51a7d5");

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "Content", "Created", "CreatedBy", "IsActive", "IsDeleted", "Title", "Updated", "UpdatedBy", "UserId" },
                values: new object[] { "374aef84-52f9-4873-855d-6ab420ba675e", "5G teknoloji ile Frekans bandı dha verimli kullanılmaya başlandı.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), false, false, "5G Teknolojisinin getirdiği yenilikler", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "Content", "Created", "CreatedBy", "IsActive", "IsDeleted", "Title", "Updated", "UpdatedBy", "UserId" },
                values: new object[] { "ff1f86ea-a1bb-4cff-9c38-7804a137b3ce", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), false, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null });
        }
    }
}
