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
                name: "FK_Tbl_BusinessProvider_SolutionProviderBase_Id",
                table: "Tbl_BusinessProvider");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_IndividualProvider_SolutionProviderBase_Id",
                table: "Tbl_IndividualProvider");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Project_SolutionProviderBase_SolutionProviderId",
                table: "Tbl_Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Proposal_SolutionProviderBase_SolutionProviderId",
                table: "Tbl_Proposal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolutionProviderBase",
                table: "SolutionProviderBase");

            migrationBuilder.RenameTable(
                name: "SolutionProviderBase",
                newName: "Tbl_SolutionProviderBase");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Tbl_SolutionProviderBase",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_SolutionProviderBase",
                table: "Tbl_SolutionProviderBase",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_BusinessProvider_Tbl_SolutionProviderBase_Id",
                table: "Tbl_BusinessProvider",
                column: "Id",
                principalTable: "Tbl_SolutionProviderBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_IndividualProvider_Tbl_SolutionProviderBase_Id",
                table: "Tbl_IndividualProvider",
                column: "Id",
                principalTable: "Tbl_SolutionProviderBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Project_Tbl_SolutionProviderBase_SolutionProviderId",
                table: "Tbl_Project",
                column: "SolutionProviderId",
                principalTable: "Tbl_SolutionProviderBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Proposal_Tbl_SolutionProviderBase_SolutionProviderId",
                table: "Tbl_Proposal",
                column: "SolutionProviderId",
                principalTable: "Tbl_SolutionProviderBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_BusinessProvider_Tbl_SolutionProviderBase_Id",
                table: "Tbl_BusinessProvider");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_IndividualProvider_Tbl_SolutionProviderBase_Id",
                table: "Tbl_IndividualProvider");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Project_Tbl_SolutionProviderBase_SolutionProviderId",
                table: "Tbl_Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Proposal_Tbl_SolutionProviderBase_SolutionProviderId",
                table: "Tbl_Proposal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_SolutionProviderBase",
                table: "Tbl_SolutionProviderBase");

            migrationBuilder.RenameTable(
                name: "Tbl_SolutionProviderBase",
                newName: "SolutionProviderBase");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "SolutionProviderBase",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolutionProviderBase",
                table: "SolutionProviderBase",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_BusinessProvider_SolutionProviderBase_Id",
                table: "Tbl_BusinessProvider",
                column: "Id",
                principalTable: "SolutionProviderBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_IndividualProvider_SolutionProviderBase_Id",
                table: "Tbl_IndividualProvider",
                column: "Id",
                principalTable: "SolutionProviderBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Project_SolutionProviderBase_SolutionProviderId",
                table: "Tbl_Project",
                column: "SolutionProviderId",
                principalTable: "SolutionProviderBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Proposal_SolutionProviderBase_SolutionProviderId",
                table: "Tbl_Proposal",
                column: "SolutionProviderId",
                principalTable: "SolutionProviderBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
