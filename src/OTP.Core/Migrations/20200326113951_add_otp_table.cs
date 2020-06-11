using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTP.Core.Migrations
{
    public partial class add_otp_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Otps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    RecordStatus = table.Column<int>(nullable: false),
                    AppId = table.Column<int>(nullable: false),
                    AppFeature = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    DialCode = table.Column<string>(nullable: true),
                    OtpCode = table.Column<int>(nullable: false),
                    IsUsed = table.Column<bool>(nullable: false),
                    TimeUsed = table.Column<DateTime>(nullable: true),
                    ExpiryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Otps", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Otps");
        }
    }
}
