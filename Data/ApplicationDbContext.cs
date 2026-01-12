using HCAMiniEHR.Models;
using HCAMiniEHR.Models.DTOs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HCAMiniEHR.Data
{
    public class ApplicationDbContext
        : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<LabOrder> LabOrders { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 🔥 VERY IMPORTANT: call base FIRST
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Healthcare");

            modelBuilder.Entity<AppointmentListDto>().HasNoKey();

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Appointments)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Appointment>()
                .HasMany(a => a.LabOrders)
                .WithOne(l => l.Appointment)
                .HasForeignKey(l => l.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
