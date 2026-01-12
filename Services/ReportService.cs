using HCAMiniEHR.Data;
using HCAMiniEHR.DTOs;
using HCAMiniEHR.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace HCAMiniEHR.Services
{
    public class ReportService
    {
        private readonly ApplicationDbContext _context;

        public ReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1️⃣ Pending Lab Orders
        public async Task<List<PendingLabOrderDto>> GetPendingLabOrdersAsync()
        {
            return await _context.LabOrders
                .Where(l => l.Status == "Pending")
                .Select(l => new PendingLabOrderDto
                {
                    PatientName = l.Appointment.Patient.FullName,
                    DoctorName = l.Appointment.Doctor.FullName,
                    TestName = l.TestName
                })
                .ToListAsync();
        }

        // 2️⃣ Patients Without Future Follow-Up
        public async Task<List<PatientWithoutFollowUpDto>> GetPatientsWithoutFollowUpAsync()
        {
            var today = DateTime.Today;

            return await _context.Patients
                .Where(p => !p.Appointments.Any(a => a.AppointmentDate > today))
                .Select(p => new PatientWithoutFollowUpDto
                {
                    PatientId = p.PatientId,
                    PatientName = p.FullName
                })
                .ToListAsync();
        }

        // 3️⃣ Doctor Productivity (BONUS)
        public async Task<List<DoctorProductivityDto>> GetDoctorProductivityAsync()
        {
            return await _context.Appointments
                .GroupBy(a => a.Doctor.FullName)
                .Select(g => new DoctorProductivityDto
                {
                    DoctorName = g.Key,
                    TotalAppointments = g.Count()
                })
                .OrderByDescending(d => d.TotalAppointments)
                .ToListAsync();
        }
    }
}
