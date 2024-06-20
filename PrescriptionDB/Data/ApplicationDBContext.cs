using Microsoft.EntityFrameworkCore;
using PrescriptionDB.Models;

namespace PrescriptionDB.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Doctor> Doctors { get; set; } = null!;
        public DbSet<PharmaceuticalCompany> PharmaceuticalCompanies { get; set; } = null!;
        public DbSet<Drug> Drugs { get; set; } = null!;
        public DbSet<Pharmacy> Pharmacies { get; set; } = null!;
        public DbSet<Prescription> Prescriptions { get; set; } = null!;
        public DbSet<Contract> Contracts { get; set; } = null!;
        public DbSet<PharmacyDrug> PharmacyDrugs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureCompositeKeys(modelBuilder);
            ConfigureRelationships(modelBuilder);
        }

        private void ConfigureCompositeKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drug>()
                .HasKey(d => new { d.TradeName, d.CompanyName });

            modelBuilder.Entity<PharmacyDrug>()
                .HasKey(pd => new { pd.PharmacyName, pd.DrugTradeName, pd.CompanyName });
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.PrimaryPhysician)
                .WithMany(d => d.Patients)
                .HasForeignKey(p => p.PrimaryPhysicianSSN);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Patient)
                .WithMany(pt => pt.Prescriptions)
                .HasForeignKey(p => p.PatientSSN);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Doctor)
                .WithMany(d => d.Prescriptions)
                .HasForeignKey(p => p.DoctorSSN);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Drug)
                .WithMany(d => d.Prescriptions)
                .HasForeignKey(p => new { p.DrugTradeName, p.CompanyName });

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.PharmaceuticalCompany)
                .WithMany(pc => pc.Contracts)
                .HasForeignKey(c => c.CompanyName);

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Pharmacy)
                .WithMany(ph => ph.Contracts)
                .HasForeignKey(c => c.PharmacyName);

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Supervisor)
                .WithMany(d => d.SupervisedContracts)
                .HasForeignKey(c => c.SupervisorSSN);

            modelBuilder.Entity<PharmacyDrug>()
                .HasOne(pd => pd.Pharmacy)
                .WithMany(ph => ph.PharmacyDrugs)
                .HasForeignKey(pd => pd.PharmacyName);

            modelBuilder.Entity<PharmacyDrug>()
                .HasOne(pd => pd.Drug)
                .WithMany(d => d.PharmacyDrugs)
                .HasForeignKey(pd => new { pd.DrugTradeName, pd.CompanyName });
        }
    }
}
