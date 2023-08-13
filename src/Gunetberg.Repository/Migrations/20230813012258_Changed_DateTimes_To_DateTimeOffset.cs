using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gunetberg.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Changed_DateTimes_To_DateTimeOffset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("5de8f89b-f367-49b2-8abd-d8a934954c56"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ba888aac-4287-48c4-95ce-32c4558a44da"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "tags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ca1c0855-1c7c-4f11-bde1-718488c15385"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("0f6aedaa-22b9-4a36-bada-04ca2bca4d0a"));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "posts",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "posts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("e56a6b86-5a89-40be-a756-f8f2b1f6497f"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("5c011623-4d78-4788-81b3-353b7ac300c5"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ba888aac-4287-48c4-95ce-32c4558a44da"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("5de8f89b-f367-49b2-8abd-d8a934954c56"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "tags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("0f6aedaa-22b9-4a36-bada-04ca2bca4d0a"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ca1c0855-1c7c-4f11-bde1-718488c15385"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "posts",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "posts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("5c011623-4d78-4788-81b3-353b7ac300c5"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("e56a6b86-5a89-40be-a756-f8f2b1f6497f"));
        }
    }
}
