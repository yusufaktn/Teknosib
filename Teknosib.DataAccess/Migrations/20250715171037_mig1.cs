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
                name: "Tbl_Address",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    City = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    District = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddressLine = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Address", x => x.AddressId);
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
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_LegalEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AverageRating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalReviews = table.Column<int>(type: "int", nullable: false),
                    CompletedProjects = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_LegalEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_LegalEntity_Tbl_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Tbl_Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_AppUser",
                columns: table => new
                {
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LegalEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsProfileCompleted = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_AppUser", x => x.AppUserId);
                    table.ForeignKey(
                        name: "FK_Tbl_AppUser_Tbl_LegalEntity_LegalEntityId",
                        column: x => x.LegalEntityId,
                        principalTable: "Tbl_LegalEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    EmployeeCount = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    ExpertiseAreas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceYear = table.Column<int>(type: "int", nullable: false),
                    ContentEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Company_Tbl_LegalEntity_Id",
                        column: x => x.Id,
                        principalTable: "Tbl_LegalEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Institution",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    InstitutionCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OfficialTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AuthorityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AuthorityTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Institution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Institution_Tbl_LegalEntity_Id",
                        column: x => x.Id,
                        principalTable: "Tbl_LegalEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Problem",
                columns: table => new
                {
                    ProblemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerLegalEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    P_Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                        name: "FK_Tbl_Problem_Tbl_LegalEntity_OwnerLegalEntityId",
                        column: x => x.OwnerLegalEntityId,
                        principalTable: "Tbl_LegalEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_SupportCall",
                columns: table => new
                {
                    SupportCallId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PublisherLegalEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    SupportAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_SupportCall", x => x.SupportCallId);
                    table.ForeignKey(
                        name: "FK_Tbl_SupportCall_Tbl_LegalEntity_PublisherLegalEntityId",
                        column: x => x.PublisherLegalEntityId,
                        principalTable: "Tbl_LegalEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Project",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProblemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FunderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProjectDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ComplatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectStatus = table.Column<int>(type: "int", nullable: false),
                    FinalBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Tbl_Project_Tbl_LegalEntity_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Tbl_LegalEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Project_Tbl_LegalEntity_FunderId",
                        column: x => x.FunderId,
                        principalTable: "Tbl_LegalEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Project_Tbl_LegalEntity_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Tbl_LegalEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Project_Tbl_Problem_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "Tbl_Problem",
                        principalColumn: "ProblemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Proposal",
                columns: table => new
                {
                    ProposalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProblemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProviderLegalEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppliedSupportCallId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OfferDetails = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProposalStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Proposal", x => x.ProposalId);
                    table.ForeignKey(
                        name: "FK_Tbl_Proposal_Tbl_LegalEntity_ProviderLegalEntityId",
                        column: x => x.ProviderLegalEntityId,
                        principalTable: "Tbl_LegalEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Proposal_Tbl_Problem_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "Tbl_Problem",
                        principalColumn: "ProblemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Proposal_Tbl_SupportCall_AppliedSupportCallId",
                        column: x => x.AppliedSupportCallId,
                        principalTable: "Tbl_SupportCall",
                        principalColumn: "SupportCallId",
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
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                name: "IX_Tbl_AppUser_LegalEntityId",
                table: "Tbl_AppUser",
                column: "LegalEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_LegalEntity_AddressId",
                table: "Tbl_LegalEntity",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Problem_CategoryId",
                table: "Tbl_Problem",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Problem_OwnerLegalEntityId",
                table: "Tbl_Problem",
                column: "OwnerLegalEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Project_ClientId",
                table: "Tbl_Project",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Project_FunderId",
                table: "Tbl_Project",
                column: "FunderId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Project_ProblemId",
                table: "Tbl_Project",
                column: "ProblemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Project_ProviderId",
                table: "Tbl_Project",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Proposal_AppliedSupportCallId",
                table: "Tbl_Proposal",
                column: "AppliedSupportCallId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Proposal_ProblemId",
                table: "Tbl_Proposal",
                column: "ProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Proposal_ProviderLegalEntityId",
                table: "Tbl_Proposal",
                column: "ProviderLegalEntityId");

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
                name: "IX_Tbl_SupportCall_PublisherLegalEntityId",
                table: "Tbl_SupportCall",
                column: "PublisherLegalEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Company");

            migrationBuilder.DropTable(
                name: "Tbl_Institution");

            migrationBuilder.DropTable(
                name: "Tbl_Proposal");

            migrationBuilder.DropTable(
                name: "Tbl_Review");

            migrationBuilder.DropTable(
                name: "Tbl_SupportCall");

            migrationBuilder.DropTable(
                name: "Tbl_AppUser");

            migrationBuilder.DropTable(
                name: "Tbl_Project");

            migrationBuilder.DropTable(
                name: "Tbl_Problem");

            migrationBuilder.DropTable(
                name: "Tbl_Category");

            migrationBuilder.DropTable(
                name: "Tbl_LegalEntity");

            migrationBuilder.DropTable(
                name: "Tbl_Address");
        }
    }
}
