using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluentBlog.Migrations
{
    public partial class AddGitHubColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GitHub",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Post",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 11, 12, 2, 0, 415, DateTimeKind.Utc).AddTicks(7020),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 11, 2, 51, 4, 225, DateTimeKind.Utc).AddTicks(6798));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GitHub",
                table: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Post",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 11, 2, 51, 4, 225, DateTimeKind.Utc).AddTicks(6798),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 11, 12, 2, 0, 415, DateTimeKind.Utc).AddTicks(7020));
        }
    }
}
