using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Host.Migrations
{
    public partial class AddComplianceModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "compliance_items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Authority = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", maxLength: 2000, nullable: true).Annotation("MySql:CharSet", "utf8mb4"),
                    DueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ResponsiblePersonId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ResponsiblePersonName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true).Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CompletedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    SubmissionReference = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true).Annotation("MySql:CharSet", "utf8mb4"),
                    Notes = table.Column<string>(type: "longtext", maxLength: 2000, nullable: true).Annotation("MySql:CharSet", "utf8mb4"),
                    AcademicYear = table.Column<int>(type: "int", nullable: false),
                    IsRecurring = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    RecurrencePattern = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true).Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table => table.PrimaryKey("PK_compliance_items", x => x.Id))
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_compliance_items_TenantId_Authority_AcademicYear",
                table: "compliance_items",
                columns: new[] { "TenantId", "Authority", "AcademicYear" });

            migrationBuilder.CreateIndex(
                name: "IX_compliance_items_TenantId_DueDate",
                table: "compliance_items",
                columns: new[] { "TenantId", "DueDate" });

            migrationBuilder.CreateTable(
                name: "aishe_returns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AcademicYear = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    InstitutionType = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true).Annotation("MySql:CharSet", "utf8mb4"),
                    EstablishmentYear = table.Column<int>(type: "int", nullable: true),
                    TotalProgrammes = table.Column<int>(type: "int", nullable: true),
                    TotalDepartments = table.Column<int>(type: "int", nullable: true),
                    TotalStudentsEnrolled = table.Column<int>(type: "int", nullable: true),
                    MaleStudents = table.Column<int>(type: "int", nullable: true),
                    FemaleStudents = table.Column<int>(type: "int", nullable: true),
                    ScStudents = table.Column<int>(type: "int", nullable: true),
                    StStudents = table.Column<int>(type: "int", nullable: true),
                    ObcStudents = table.Column<int>(type: "int", nullable: true),
                    TotalFaculty = table.Column<int>(type: "int", nullable: true),
                    MaleFaculty = table.Column<int>(type: "int", nullable: true),
                    FemaleFaculty = table.Column<int>(type: "int", nullable: true),
                    PhdFaculty = table.Column<int>(type: "int", nullable: true),
                    TotalBuiltAreaSqm = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    TotalLibraryBooks = table.Column<int>(type: "int", nullable: true),
                    CompiledAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    SubmittedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    SubmissionReference = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true).Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table => table.PrimaryKey("PK_aishe_returns", x => x.Id))
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_aishe_returns_TenantId_AcademicYear",
                table: "aishe_returns",
                columns: new[] { "TenantId", "AcademicYear" },
                unique: true);

            migrationBuilder.CreateTable(
                name: "compliance_notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ComplianceItemId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Message = table.Column<string>(type: "longtext", maxLength: 500, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    SentAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RecipientUserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsRead = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NotificationType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table => table.PrimaryKey("PK_compliance_notifications", x => x.Id))
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_compliance_notifications_TenantId_RecipientUserId_IsRead",
                table: "compliance_notifications",
                columns: new[] { "TenantId", "RecipientUserId", "IsRead" });

            migrationBuilder.CreateIndex(
                name: "IX_compliance_notifications_TenantId_ComplianceItemId",
                table: "compliance_notifications",
                columns: new[] { "TenantId", "ComplianceItemId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "compliance_notifications");
            migrationBuilder.DropTable(name: "aishe_returns");
            migrationBuilder.DropTable(name: "compliance_items");
        }
    }
}

