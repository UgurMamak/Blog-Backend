using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class PostSeedScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: "374aef84-52f9-4873-855d-6ab420ba675e");

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: "6d2201e7-a0f9-4b05-9627-473c8f3827e3");

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "Content", "Created", "CreatedBy", "IsActive", "IsDeleted", "Title", "Updated", "UpdatedBy", "UserId" },
                values: new object[] { "d1013284-4e87-47c6-b28f-47ece4ba9888", "5G teknoloji ile Frekans bandı dha verimli kullanılmaya başlandı.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), false, false, "5G Teknolojisinin getirdiği yenilikler", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "6a818bb9-8bd3-421a-8fd8-7c0d18df8094" });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "Content", "Created", "CreatedBy", "IsActive", "IsDeleted", "Title", "Updated", "UpdatedBy", "UserId" },
                values: new object[] { "34bb076e-36ca-4f6b-bb78-7949daeef2b1", "metabolizmayı güçlendirir. Daha dinç ve zinde olurusunuz.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), false, false, "Spor yapmanın faydaları", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "6a818bb9-8bd3-421a-8fd8-7c0d18df8094" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: "34bb076e-36ca-4f6b-bb78-7949daeef2b1");

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: "d1013284-4e87-47c6-b28f-47ece4ba9888");

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "Content", "Created", "CreatedBy", "IsActive", "IsDeleted", "Title", "Updated", "UpdatedBy", "UserId" },
                values: new object[] { "374aef84-52f9-4873-855d-6ab420ba675e", "5G teknoloji ile Frekans bandı dha verimli kullanılmaya başlandı.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), false, false, "5G Teknolojisinin getirdiği yenilikler", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "Content", "Created", "CreatedBy", "IsActive", "IsDeleted", "Title", "Updated", "UpdatedBy", "UserId" },
                values: new object[] { "6d2201e7-a0f9-4b05-9627-473c8f3827e3", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), false, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null });
        }
    }
}
