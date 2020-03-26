using Microsoft.EntityFrameworkCore.Migrations;

namespace OTP.Core.Migrations
{
    public partial class add_otptypes_view : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var txt = @"create view otptypemodel as select x.* from OtpTypes x where x.RecordStatus != 3 and x.RecordStatus != 4";
            migrationBuilder.Sql(txt);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
