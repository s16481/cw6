using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cw6.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionsMedicaments { get; set; }

        public DataContext() { }

        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrescriptionMedicament>()
                .HasKey(c => new { c.IdMedicament, c.IdPrescription });
            base.OnModelCreating(modelBuilder);
            var dictDoctor = new List<Doctor>();
            var dictMedicament = new List<Medicament>();
            var dictPatient = new List<Patient>();
            var dictPrescrtiption = new List<Prescription>();
            var dictPrescrtiptionMedicament = new List<PrescriptionMedicament>();
            //dictStudies.Add(new Studies { IdStudies = 1, Name = "IT", Description = "AAA" });
        }
    }
}