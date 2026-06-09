using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Host.Migrations
{
    public partial class AddNirfModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nirf_submissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RankingYear = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    OverallScore = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    EstimatedRank = table.Column<int>(type: "int", nullable: true),
                    SubmittedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table => table.PrimaryKey("PK_nirf_submissions", x => x.Id))
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_nirf_submissions_TenantId_RankingYear",
                table: "nirf_submissions",
                columns: new[] { "TenantId", "RankingYear" },
                unique: true);

            migrationBuilder.CreateTable(
                name: "nirf_parameter_scores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SubmissionId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Parameter = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    RawScore = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    WeightedScore = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    DataJson = table.Column<string>(type: "longtext", maxLength: 10000, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    IsManualOverride = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nirf_parameter_scores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nirf_parameter_scores_nirf_submissions_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "nirf_submissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_nirf_parameter_scores_TenantId_SubmissionId_Parameter",
                table: "nirf_parameter_scores",
                columns: new[] { "TenantId", "SubmissionId", "Parameter" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_nirf_parameter_scores_SubmissionId",
                table: "nirf_parameter_scores",
                column: "SubmissionId");

            migrationBuilder.CreateTable(
                name: "nirf_rank_history",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RankingYear = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    Rank = table.Column<int>(type: "int", nullable: true),
                    Score = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    TeachingLearningScore = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    ResearchScore = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    GraduationOutcomesScore = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    OutreachScore = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    PerceptionScore = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table => table.PrimaryKey("PK_nirf_rank_history", x => x.Id))
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_nirf_rank_history_TenantId_RankingYear_Category",
                table: "nirf_rank_history",
                columns: new[] { "TenantId", "RankingYear", "Category" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "nirf_parameter_scores");
            migrationBuilder.DropTable(name: "nirf_submissions");
            migrationBuilder.DropTable(name: "nirf_rank_history");
        }
    }
}

