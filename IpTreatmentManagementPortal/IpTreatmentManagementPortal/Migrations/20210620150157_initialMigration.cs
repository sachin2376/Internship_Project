using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IpTreatmentManagementPortal.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InitiateClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ailment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TreatmentPackageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsurerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitiateClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insurers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsurerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InsurerPackageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InsurerAmountLimit = table.Column<double>(type: "float", nullable: false),
                    DisbursementDuration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IpTreatmentPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ailmentCategory = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpTreatmentPackages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    PackageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PackageName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TestDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.PackageId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientAge = table.Column<int>(type: "int", nullable: false),
                    Ailment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TreatmentpackageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TreatmentCommenceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    treatmentStatus = table.Column<int>(type: "int", nullable: false),
                    InitiateClaimId = table.Column<int>(type: "int", nullable: true),
                    TreatmentPlanId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Specialists",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AreaOfExpertise = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpInYears = table.Column<int>(type: "int", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentPlans",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PackageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    SpecialistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TreatmentCommencementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TreatmentEnddate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentPlans", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InitiateClaims");

            migrationBuilder.DropTable(
                name: "Insurers");

            migrationBuilder.DropTable(
                name: "IpTreatmentPackages");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Specialists");

            migrationBuilder.DropTable(
                name: "TreatmentPlans");
        }
    }
}
