using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teknosib.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Tbl_AppUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "Tbl_AppUser",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Tbl_AppUser");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "Tbl_AppUser");
        }
    }
}
