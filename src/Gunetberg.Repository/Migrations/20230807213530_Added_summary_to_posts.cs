using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gunetberg.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Added_summary_to_posts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ba888aac-4287-48c4-95ce-32c4558a44da"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("04124010-8aec-455a-b84d-b7067ebf150e"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "tags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("0f6aedaa-22b9-4a36-bada-04ca2bca4d0a"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("0d19fd15-7b2a-443d-b516-056d4fe33eef"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "posts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("5c011623-4d78-4788-81b3-353b7ac300c5"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("fe075721-986c-4849-93cf-f459ce28bb04"));

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "posts",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summary",
                table: "posts");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("04124010-8aec-455a-b84d-b7067ebf150e"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ba888aac-4287-48c4-95ce-32c4558a44da"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "tags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("0d19fd15-7b2a-443d-b516-056d4fe33eef"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("0f6aedaa-22b9-4a36-bada-04ca2bca4d0a"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "posts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("fe075721-986c-4849-93cf-f459ce28bb04"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("5c011623-4d78-4788-81b3-353b7ac300c5"));
        }
    }
}
