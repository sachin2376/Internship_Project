using Microsoft.EntityFrameworkCore.Migrations;

namespace IpTreatmentManagementPortal.Migrations
{
    public partial class DataTypeModificationForDateAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "treatmentStatus",
                table: "Patients",
                type: "varchar(25)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "treatmentStatus",
                table: "Patients",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(25)");
        }
    }
}
