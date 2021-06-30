using Microsoft.EntityFrameworkCore.Migrations;

namespace IpTreatmentManagementPortal.Migrations
{
    public partial class DataTypeModificationsDone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ailmentCategory",
                table: "IpTreatmentPackages",
                type: "varchar(25)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ailmentCategory",
                table: "IpTreatmentPackages",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(25)");
        }
    }
}
