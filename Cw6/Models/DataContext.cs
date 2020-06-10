using System;
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
            dictDoctor.Add(new Doctor {IdDoctor = 1, FirstName = "Tadeusz", LastName = "Twardy", Email = "brak"});
            dictDoctor.Add(new Doctor {IdDoctor = 2, FirstName = "Jan", LastName = "Miazga", Email = "miazga@miazga.pl"});
            dictPatient.Add(new Patient {idPatient = 1, FirstName = "Edek", LastName = "Kluska", BirthDate = new DateTime(1993, 11, 5)});
            dictPatient.Add(new Patient {idPatient = 2, FirstName = "Józek", LastName = "A"});
            modelBuilder.Entity<Doctor>()
                .HasData(dictDoctor);
            modelBuilder.Entity<Patient>()
                .HasData(dictPatient);
        }
    }
}