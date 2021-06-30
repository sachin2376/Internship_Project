using System;
using System.Collections.Generic;
using IpTreatmentManagementPortal.Entities;
using IpTreatmentManagementPortal.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace IpTreatmentManagementPortal.Context
{
    public class PatientDBContext : DbContext
    {
        public PatientDBContext(DbContextOptions<PatientDBContext> dbContextOptions) : base(dbContextOptions)
        {
        }


        public virtual DbSet<IpTreatmentPackage> IpTreatmentPackages { get; set; }
        public virtual DbSet<Package> Packages{ get; set; }
        public virtual DbSet<Specialist> Specialists{ get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Insurer> Insurers { get; set; }
        public virtual DbSet<InitiateClaim> InitiateClaims{ get; set; }
        public virtual DbSet<TreatmentPlan> TreatmentPlans { get; set; }
        public virtual DbSet<Ailment> Ailments { get; set; }
        public virtual DbSet<UserModel> UserModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<Package>()
                        .Property(p => p.TestDetails)
                        .HasColumnType("varchar(50)");

            _ = modelBuilder.Entity<TreatmentPlan>()
                        .Property(p => p.TestDetails)
                        .HasColumnType("varchar(50)");

            modelBuilder.Entity<IpTreatmentPackage>()
                        .Property(p => p.AilmentCategory)
                        .HasColumnType("varchar(25)");

            modelBuilder.Entity<Patient>()
                        .Property(p => p.TreatmentStatus)
                        .HasColumnType("varchar(25)");

            modelBuilder.Entity<Ailment>()
                        .HasNoKey();

        }

    }

}
