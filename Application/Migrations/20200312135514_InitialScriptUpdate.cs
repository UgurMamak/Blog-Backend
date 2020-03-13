using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class InitialScriptUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_User_OwnerId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_PostCategory_PostCategoryId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_PostCategoryId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Comment_OwnerId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "PostCategory");

            migrationBuilder.DropColumn(
                name: "PostCategoryId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Comment");

            migrationBuilder.AddColumn<long>(
                name: "PostId",
                table: "PostCategory",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Comment",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PostCategory_PostId",
                table: "PostCategory",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_User_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostCategory_Post_PostId",
                table: "PostCategory",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_User_UserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_PostCategory_Post_PostId",
                table: "PostCategory");

            migrationBuilder.DropIndex(
                name: "IX_PostCategory_PostId",
                table: "PostCategory");

            migrationBuilder.DropIndex(
                name: "IX_Comment_UserId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "PostCategory");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comment");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "PostCategory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostCategoryId",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Post_PostCategoryId",
                table: "Post",
                column: "PostCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_OwnerId",
                table: "Comment",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_User_OwnerId",
                table: "Comment",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_PostCategory_PostCategoryId",
                table: "Post",
                column: "PostCategoryId",
                principalTable: "PostCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
