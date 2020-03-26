using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTP.Core.Migrations
{
    public partial class add_app_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    RecordStatus = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    AppSecret = table.Column<string>(nullable: false),
                    OtpTypeId = table.Column<int>(nullable: false),
                    OtpLength = table.Column<int>(nullable: false),
                    HasExpiry = table.Column<bool>(nullable: false),
                    ExpiryPeriod = table.Column<TimeSpan>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apps", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apps");
        }
    }
}
