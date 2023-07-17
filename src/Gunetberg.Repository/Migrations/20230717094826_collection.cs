using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gunetberg.Repository.Migrations
{
    /// <inheritdoc />
    public partial class collection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("41aee6e4-aa53-4a26-a22a-2567ea76560e"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("63198804-8232-463e-a5a9-1e10ddef943e"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "tags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("fd5bccfb-1b76-40da-98f5-38ed32762192"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("4b902c61-364b-4baf-bd21-500aeccbfec6"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "posts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("46d27a31-849c-497b-a5cb-0a5e11f2a726"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("dc37ddb7-bd57-496e-9ce4-e1e93897e036"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("63198804-8232-463e-a5a9-1e10ddef943e"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("41aee6e4-aa53-4a26-a22a-2567ea76560e"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "tags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4b902c61-364b-4baf-bd21-500aeccbfec6"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("fd5bccfb-1b76-40da-98f5-38ed32762192"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "posts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("dc37ddb7-bd57-496e-9ce4-e1e93897e036"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("46d27a31-849c-497b-a5cb-0a5e11f2a726"));
        }
    }
}
