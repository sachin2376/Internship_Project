﻿// <auto-generated />
using System;
using IpTreatmentManagementPortal.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IpTreatmentManagementPortal.Migrations
{
    [DbContext(typeof(PatientDBContext))]
    partial class PatientDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IpTreatmentManagementPortal.Entities.Ailment", b =>
                {
                    b.Property<string>("AilmentName")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Ailments");
                });

            modelBuilder.Entity("IpTreatmentManagementPortal.Entities.InitiateClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ailment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsurerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TreatmentPackageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InitiateClaims");
                });

            modelBuilder.Entity("IpTreatmentManagementPortal.Entities.Insurer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DisbursementDuration")
                        .HasColumnType("int");

                    b.Property<double>("InsurerAmountLimit")
                        .HasColumnType("float");

                    b.Property<string>("InsurerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsurerPackageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Insurers");
                });

            modelBuilder.Entity("IpTreatmentManagementPortal.Entities.IpTreatmentPackage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AilmentCategory")
                        .HasColumnType("varchar(25)");

                    b.Property<string>("PackageId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IpTreatmentPackages");
                });

            modelBuilder.Entity("IpTreatmentManagementPortal.Entities.Package", b =>
                {
                    b.Property<string>("PackageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("PackageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TestDetails")
                        .HasColumnType("varchar(50)");

                    b.HasKey("PackageId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("IpTreatmentManagementPortal.Entities.Patient", b =>
                {
                    b.Property<string>("PatientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Ailment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InitiateClaimId")
                        .HasColumnType("int");

                    b.Property<int>("PatientAge")
                        .HasColumnType("int");

                    b.Property<string>("PatientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TreatmentCommenceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TreatmentPlanId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TreatmentStatus")
                        .HasColumnType("varchar(25)");

                    b.Property<string>("TreatmentpackageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("IpTreatmentManagementPortal.Entities.Specialist", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AreaOfExpertise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExpInYears")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specialists");
                });

            modelBuilder.Entity("IpTreatmentManagementPortal.Entities.TreatmentPlan", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<string>("PackageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialistName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TestDetails")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("TreatmentCommencementDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TreatmentEnddate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TreatmentPlans");
                });

            modelBuilder.Entity("IpTreatmentManagementPortal.UserModel", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Username");

                    b.ToTable("UserModels");
                });
#pragma warning restore 612, 618
        }
    }
}
