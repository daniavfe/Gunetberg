using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gunetberg.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Added_role_to_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("04124010-8aec-455a-b84d-b7067ebf150e"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("2fec2893-21cf-432e-84c6-6934d811fb83"));

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "tags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("0d19fd15-7b2a-443d-b516-056d4fe33eef"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("40f6a8c0-454f-4231-b831-a093820007e5"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "posts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("fe075721-986c-4849-93cf-f459ce28bb04"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("74dab7e0-3d8d-4e28-9c97-ec074df5ad91"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "users");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("2fec2893-21cf-432e-84c6-6934d811fb83"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("04124010-8aec-455a-b84d-b7067ebf150e"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "tags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("40f6a8c0-454f-4231-b831-a093820007e5"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("0d19fd15-7b2a-443d-b516-056d4fe33eef"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "posts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("74dab7e0-3d8d-4e28-9c97-ec074df5ad91"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("fe075721-986c-4849-93cf-f459ce28bb04"));
        }
    }
}
