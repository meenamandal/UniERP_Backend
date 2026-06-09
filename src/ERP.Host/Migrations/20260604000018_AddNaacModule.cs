using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Host.Migrations
{
    public partial class AddNaacModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ssr_reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AcademicYear = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ApprovedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table => table.PrimaryKey("PK_ssr_reports", x => x.Id))
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ssr_reports_TenantId_AcademicYear",
                table: "ssr_reports",
                columns: new[] { "TenantId", "AcademicYear" },
                unique: true);

            migrationBuilder.CreateTable(
                name: "ssr_sections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SsrId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CriterionNumber = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    IndicatorNumber = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "longtext", nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    AutoMetrics = table.Column<string>(type: "longtext", maxLength: 5000, nullable: true).Annotation("MySql:CharSet", "utf8mb4"),
                    LastEditedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    LastEditedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ssr_sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ssr_sections_ssr_reports_SsrId",
                        column: x => x.SsrId,
                        principalTable: "ssr_reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ssr_sections_TenantId_SsrId_IndicatorNumber",
                table: "ssr_sections",
                columns: new[] { "TenantId", "SsrId", "IndicatorNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_ssr_sections_SsrId",
                table: "ssr_sections",
                column: "SsrId");

            migrationBuilder.CreateTable(
                name: "dvv_queries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SsrId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    QueryNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    CriterionNumber = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    IndicatorNumber = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    QueryText = table.Column<string>(type: "longtext", maxLength: 5000, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    Response = table.Column<string>(type: "longtext", maxLength: 10000, nullable: true).Annotation("MySql:CharSet", "utf8mb4"),
                    SupportingDocUrls = table.Column<string>(type: "longtext", maxLength: 2000, nullable: true).Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ReceivedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RespondedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RespondedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table => table.PrimaryKey("PK_dvv_queries", x => x.Id))
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_dvv_queries_TenantId_SsrId",
                table: "dvv_queries",
                columns: new[] { "TenantId", "SsrId" });

            migrationBuilder.CreateIndex(
                name: "IX_dvv_queries_TenantId_Status",
                table: "dvv_queries",
                columns: new[] { "TenantId", "Status" });

            migrationBuilder.CreateTable(
                name: "aqar_reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AcademicYear = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table => table.PrimaryKey("PK_aqar_reports", x => x.Id))
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_aqar_reports_TenantId_AcademicYear",
                table: "aqar_reports",
                columns: new[] { "TenantId", "AcademicYear" },
                unique: true);

            migrationBuilder.CreateTable(
                name: "aqar_sections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AqarId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CriterionNumber = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    AssignedTo = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Content = table.Column<string>(type: "longtext", nullable: true).Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ReviewComment = table.Column<string>(type: "longtext", maxLength: 2000, nullable: true).Annotation("MySql:CharSet", "utf8mb4"),
                    ReviewedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ReviewedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aqar_sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_aqar_sections_aqar_reports_AqarId",
                        column: x => x.AqarId,
                        principalTable: "aqar_reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_aqar_sections_TenantId_AqarId",
                table: "aqar_sections",
                columns: new[] { "TenantId", "AqarId" });

            migrationBuilder.CreateIndex(
                name: "IX_aqar_sections_AqarId",
                table: "aqar_sections",
                column: "AqarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "aqar_sections");
            migrationBuilder.DropTable(name: "aqar_reports");
            migrationBuilder.DropTable(name: "dvv_queries");
            migrationBuilder.DropTable(name: "ssr_sections");
            migrationBuilder.DropTable(name: "ssr_reports");
        }
    }
}

