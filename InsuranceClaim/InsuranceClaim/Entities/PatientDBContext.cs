using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InsuranceClaim.Entities
{
    public partial class PatientDBContext : DbContext
    {
        public PatientDBContext()
        {
        }

        public PatientDBContext(DbContextOptions<PatientDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ailment> Ailments { get; set; }
        public virtual DbSet<InitiateClaim> InitiateClaims { get; set; }
        public virtual DbSet<Insurer> Insurers { get; set; }
        public virtual DbSet<IpTreatmentPackage> IpTreatmentPackages { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Specialist> Specialists { get; set; }
        public virtual DbSet<TreatmentPlan> TreatmentPlans { get; set; }
        public virtual DbSet<UserModel> UserModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=PatientDB;User Id=SA;Password=reallyStrongPwd123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Ailment>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<IpTreatmentPackage>(entity =>
            {
                entity.Property(e => e.AilmentCategory)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.Property(e => e.TestDetails)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.TreatmentStatus)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TreatmentPlan>(entity =>
            {
                entity.Property(e => e.TestDetails)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.Property(e => e.Username).HasMaxLength(10);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
