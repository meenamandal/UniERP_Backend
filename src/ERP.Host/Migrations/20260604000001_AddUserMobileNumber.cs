using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Host.Migrations
{
    public partial class AddUserMobileNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "users",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_users_TenantId_MobileNumber",
                table: "users",
                columns: new[] { "TenantId", "MobileNumber" },
                unique: true,
                filter: "MobileNumber IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(name: "IX_users_TenantId_MobileNumber", table: "users");
            migrationBuilder.DropColumn(name: "MobileNumber", table: "users");
        }
    }
}
