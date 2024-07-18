using Microsoft.EntityFrameworkCore;

namespace MedicalAssistant_API.Models
{
    public class MedicalAssistantContext : DbContext
    {
        public MedicalAssistantContext(DbContextOptions<MedicalAssistantContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<HealthMetric> HealthMetrics { get; set; }
        public DbSet<Prediction> Predictions { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasKey(p => p.PatientID);
            modelBuilder.Entity<MedicalRecord>().HasKey(m => m.RecordID);
            modelBuilder.Entity<HealthMetric>().HasKey(h => h.MetricID);
            modelBuilder.Entity<Prediction>().HasKey(p => p.PredictionID);
            modelBuilder.Entity<Appointment>().HasKey(a => a.AppointmentID);
            modelBuilder.Entity<User>().HasKey(u => u.UserID);


            modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientID);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorID);
            // Additional configurations if needed
        }
    }
}
