using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teknosib.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_AppUser_Tbl_LegalEntity_LegalEntityId",
                table: "Tbl_AppUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_AppUser_Tbl_LegalEntity_LegalEntityId",
                table: "Tbl_AppUser",
                column: "LegalEntityId",
                principalTable: "Tbl_LegalEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_AppUser_Tbl_LegalEntity_LegalEntityId",
                table: "Tbl_AppUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_AppUser_Tbl_LegalEntity_LegalEntityId",
                table: "Tbl_AppUser",
                column: "LegalEntityId",
                principalTable: "Tbl_LegalEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
