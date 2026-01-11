using HCAMiniEHR.Data;
using HCAMiniEHR.Models;
using Microsoft.EntityFrameworkCore;

namespace HCAMiniEHR.Services
{
    public class AppointmentService
    {
        private readonly ApplicationDbContext _context;

        public AppointmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ List appointments for a patient (with doctor)
        public async Task<List<Appointment>> GetByPatientAsync(int patientId)
        {
            return await _context.Appointments
                .Include(a => a.Doctor)
                .Where(a => a.PatientId == patientId)
                .OrderByDescending(a => a.AppointmentDate)
                .ToListAsync();
        }

        // ✅ Add appointment using Stored Procedure
        public async Task CreateUsingSPAsync(
            int patientId,
            int doctorId,
            DateTime date,
            string status)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC Healthcare.CreateAppointment @p0, @p1, @p2, @p3",
                patientId,
                doctorId,
                date,
                status
            );
        }
    }
}
