using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teknosib.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AfterAddingBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Tbl_SolutionProvider",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Tbl_SolutionProvider",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Tbl_SolutionProvider",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Tbl_Company",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Tbl_Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Tbl_Company",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Tbl_SolutionProvider");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tbl_SolutionProvider");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Tbl_SolutionProvider");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Tbl_Company");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tbl_Company");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Tbl_Company");
        }
    }
}
