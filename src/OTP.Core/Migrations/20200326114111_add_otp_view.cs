using Microsoft.EntityFrameworkCore.Migrations;

namespace OTP.Core.Migrations
{
    public partial class add_otp_view : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var txt = @"create view otpmodel as select x.* from Otps x where x.RecordStatus != 3 and x.RecordStatus != 4";
            migrationBuilder.Sql(txt);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
