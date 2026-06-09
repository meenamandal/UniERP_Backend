using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Host.Migrations
{
    public partial class AddPlacementModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "placement_companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    Industry = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    Website = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true).Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", maxLength: 2000, nullable: true).Annotation("MySql:CharSet", "utf8mb4"),
                    LogoUrl = table.Column<string>(type: "longtext", maxLength: 1000, nullable: true).Annotation("MySql:CharSet", "utf8mb4"),
                    ContactPersonName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true).Annotation("MySql:CharSet", "utf8mb4"),
                    ContactEmail = table.Column<string>(type: "varchar(320)", maxLength: 320, nullable: true).Annotation("MySql:CharSet", "utf8mb4"),
                    ContactMobile = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true).Annotation("MySql:CharSet", "utf8mb4"),
                    TotalDrives = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TotalOffers = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    HighestPackageLpa = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m),
                    AveragePackageLpa = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table => table.PrimaryKey("PK_placement_companies", x => x.Id))
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_placement_companies_TenantId_Name",
                table: "placement_companies",
                columns: new[] { "TenantId", "Name" },
                unique: true);

            migrationBuilder.CreateTable(
                name: "placement_drives",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CompanyId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CompanyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    JobRole = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    JobDescription = table.Column<string>(type: "longtext", maxLength: 5000, nullable: true).Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true).Annotation("MySql:CharSet", "utf8mb4"),
                    PackageLpa = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    MinCgpa = table.Column<decimal>(type: "decimal(4,2)", nullable: false, defaultValue: 0m),
                    MaxBacklogs = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    EligibleBranches = table.Column<string>(type: "longtext", maxLength: 500, nullable: true).Annotation("MySql:CharSet", "utf8mb4"),
                    DriveDate = table.Column<DateOnly>(type: "date", nullable: true),
                    RegistrationDeadline = table.Column<DateOnly>(type: "date", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AcademicYear = table.Column<int>(type: "int", nullable: false),
                    TotalRegistrations = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TotalSelected = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_placement_drives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_placement_drives_placement_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "placement_companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_placement_drives_TenantId_CompanyId",
                table: "placement_drives",
                columns: new[] { "TenantId", "CompanyId" });

            migrationBuilder.CreateIndex(
                name: "IX_placement_drives_TenantId_AcademicYear",
                table: "placement_drives",
                columns: new[] { "TenantId", "AcademicYear" });

            migrationBuilder.CreateTable(
                name: "drive_registrations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DriveId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StudentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StudentName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    StudentCgpa = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    ActiveBacklogs = table.Column<int>(type: "int", nullable: false),
                    Branch = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    RegisteredAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    InterviewScheduledAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    InterviewNotes = table.Column<string>(type: "longtext", maxLength: 2000, nullable: true).Annotation("MySql:CharSet", "utf8mb4"),
                    OfferLpa = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drive_registrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_drive_registrations_placement_drives_DriveId",
                        column: x => x.DriveId,
                        principalTable: "placement_drives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_drive_registrations_TenantId_DriveId_StudentId",
                table: "drive_registrations",
                columns: new[] { "TenantId", "DriveId", "StudentId" },
                unique: true);

            migrationBuilder.CreateTable(
                name: "placement_offers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RegistrationId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DriveId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StudentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CompanyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    JobRole = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    OfferedPackageLpa = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    JoiningDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IssuedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ConfirmedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    OfferLetterBlobUrl = table.Column<string>(type: "longtext", maxLength: 1000, nullable: true).Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_placement_offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_placement_offers_drive_registrations_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "drive_registrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_placement_offers_TenantId_RegistrationId",
                table: "placement_offers",
                columns: new[] { "TenantId", "RegistrationId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_placement_offers_TenantId_DriveId",
                table: "placement_offers",
                columns: new[] { "TenantId", "DriveId" });

            migrationBuilder.CreateIndex(
                name: "IX_placement_offers_TenantId_StudentId",
                table: "placement_offers",
                columns: new[] { "TenantId", "StudentId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "placement_offers");
            migrationBuilder.DropTable(name: "drive_registrations");
            migrationBuilder.DropTable(name: "placement_drives");
            migrationBuilder.DropTable(name: "placement_companies");
        }
    }
}

