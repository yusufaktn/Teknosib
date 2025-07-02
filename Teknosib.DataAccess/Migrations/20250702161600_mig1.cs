using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teknosib.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_AppUser",
                columns: table => new
                {
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_AppUser", x => x.AppUserId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Category",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_KosgebSupport",
                columns: table => new
                {
                    KosgebSupportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OfficialUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxSupportAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_KosgebSupport", x => x.KosgebSupportId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Company",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Company", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Tbl_Company_Tbl_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Tbl_AppUser",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_SolutionProvider",
                columns: table => new
                {
                    SolutionProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExpertiseAreas = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExperienceYear = table.Column<int>(type: "int", nullable: false),
                    PortfolioUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_SolutionProvider", x => x.SolutionProviderId);
                    table.ForeignKey(
                        name: "FK_Tbl_SolutionProvider_Tbl_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Tbl_AppUser",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Problem",
                columns: table => new
                {
                    ProblemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    P_Status = table.Column<int>(type: "int", nullable: false),
                    MinBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Problem", x => x.ProblemId);
                    table.ForeignKey(
                        name: "FK_Tbl_Problem_Tbl_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Tbl_Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Problem_Tbl_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Tbl_Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Project",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProblemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KosgebSupportId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SolutionProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProjectDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ComplatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Tbl_Project_Tbl_KosgebSupport_KosgebSupportId",
                        column: x => x.KosgebSupportId,
                        principalTable: "Tbl_KosgebSupport",
                        principalColumn: "KosgebSupportId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Tbl_Project_Tbl_Problem_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "Tbl_Problem",
                        principalColumn: "ProblemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Project_Tbl_SolutionProvider_SolutionProviderId",
                        column: x => x.SolutionProviderId,
                        principalTable: "Tbl_SolutionProvider",
                        principalColumn: "SolutionProviderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Proposal",
                columns: table => new
                {
                    ProposalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProblemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SolutionProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfferDetails = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProposalStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Proposal", x => x.ProposalId);
                    table.ForeignKey(
                        name: "FK_Tbl_Proposal_Tbl_Problem_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "Tbl_Problem",
                        principalColumn: "ProblemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Proposal_Tbl_SolutionProvider_SolutionProviderId",
                        column: x => x.SolutionProviderId,
                        principalTable: "Tbl_SolutionProvider",
                        principalColumn: "SolutionProviderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Review",
                columns: table => new
                {
                    ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RevieweeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Tbl_Review_Tbl_AppUser_RevieweeId",
                        column: x => x.RevieweeId,
                        principalTable: "Tbl_AppUser",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Review_Tbl_AppUser_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "Tbl_AppUser",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Review_Tbl_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Tbl_Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_AppUser_Email",
                table: "Tbl_AppUser",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Company_AppUserId",
                table: "Tbl_Company",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Problem_CategoryId",
                table: "Tbl_Problem",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Problem_CompanyId",
                table: "Tbl_Problem",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Project_KosgebSupportId",
                table: "Tbl_Project",
                column: "KosgebSupportId",
                unique: true,
                filter: "[KosgebSupportId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Project_ProblemId",
                table: "Tbl_Project",
                column: "ProblemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Project_SolutionProviderId",
                table: "Tbl_Project",
                column: "SolutionProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Proposal_ProblemId",
                table: "Tbl_Proposal",
                column: "ProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Proposal_SolutionProviderId",
                table: "Tbl_Proposal",
                column: "SolutionProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Review_ProjectId",
                table: "Tbl_Review",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Review_RevieweeId",
                table: "Tbl_Review",
                column: "RevieweeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Review_ReviewerId",
                table: "Tbl_Review",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SolutionProvider_AppUserId",
                table: "Tbl_SolutionProvider",
                column: "AppUserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Proposal");

            migrationBuilder.DropTable(
                name: "Tbl_Review");

            migrationBuilder.DropTable(
                name: "Tbl_Project");

            migrationBuilder.DropTable(
                name: "Tbl_KosgebSupport");

            migrationBuilder.DropTable(
                name: "Tbl_Problem");

            migrationBuilder.DropTable(
                name: "Tbl_SolutionProvider");

            migrationBuilder.DropTable(
                name: "Tbl_Category");

            migrationBuilder.DropTable(
                name: "Tbl_Company");

            migrationBuilder.DropTable(
                name: "Tbl_AppUser");
        }
    }
}
