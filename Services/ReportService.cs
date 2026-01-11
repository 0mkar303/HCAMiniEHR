using HCAMiniEHR.Data;
using HCAMiniEHR.DTOs;
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

        // REPORT 1: Pending Lab Orders
        public async Task<List<PendingLabOrderDto>> GetPendingLabOrdersAsync()
        {
            return await _context.LabOrders
                .Where(l => l.Status == "Pending")
                .Select(l => new PendingLabOrderDto
                {
                    PatientName = l.Appointment.Patient.FullName,
                    TestName = l.TestName
                })
                .ToListAsync();
        }

        // REPORT 2: Patients without future appointments
        public async Task<List<string>> GetPatientsWithoutFollowUpAsync()
        {
            return await _context.Patients
                .Where(p => !p.Appointments.Any(a => a.AppointmentDate > DateTime.Now))
                .Select(p => p.FullName)
                .ToListAsync();
        }
    }
}
