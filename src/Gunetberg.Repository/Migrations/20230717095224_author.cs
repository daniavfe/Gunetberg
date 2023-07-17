using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gunetberg.Repository.Migrations
{
    /// <inheritdoc />
    public partial class author : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_users_AuthorId",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "IX_posts_AuthorId",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "posts");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("2fec2893-21cf-432e-84c6-6934d811fb83"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("41aee6e4-aa53-4a26-a22a-2567ea76560e"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "tags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("40f6a8c0-454f-4231-b831-a093820007e5"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("fd5bccfb-1b76-40da-98f5-38ed32762192"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "posts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("74dab7e0-3d8d-4e28-9c97-ec074df5ad91"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("46d27a31-849c-497b-a5cb-0a5e11f2a726"));

            migrationBuilder.CreateIndex(
                name: "IX_posts_CreatedBy",
                table: "posts",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_users_CreatedBy",
                table: "posts",
                column: "CreatedBy",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_users_CreatedBy",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "IX_posts_CreatedBy",
                table: "posts");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("41aee6e4-aa53-4a26-a22a-2567ea76560e"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("2fec2893-21cf-432e-84c6-6934d811fb83"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "tags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("fd5bccfb-1b76-40da-98f5-38ed32762192"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("40f6a8c0-454f-4231-b831-a093820007e5"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "posts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("46d27a31-849c-497b-a5cb-0a5e11f2a726"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("74dab7e0-3d8d-4e28-9c97-ec074df5ad91"));

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "posts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_posts_AuthorId",
                table: "posts",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_users_AuthorId",
                table: "posts",
                column: "AuthorId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
