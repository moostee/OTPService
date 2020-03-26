using Microsoft.EntityFrameworkCore.Migrations;

namespace OTP.Core.Migrations
{
    public partial class add_app_view : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var txt = @"create view appmodel as select x.* from Apps x where x.RecordStatus != 3 and x.RecordStatus != 4";
            migrationBuilder.Sql(txt);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
