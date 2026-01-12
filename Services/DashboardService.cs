using HCAMiniEHR.Data;
using HCAMiniEHR.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace HCAMiniEHR.Services
{
    public class DashboardService
    {
        private readonly ApplicationDbContext _context;

        public DashboardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardDto> GetDashboardDataAsync()
        {
            var today = DateTime.Today;

            return new DashboardDto
            {
                TotalPatients = await _context.Patients.CountAsync(),

                TotalAppointments = await _context.Appointments.CountAsync(),

                TodayAppointments = await _context.Appointments
                    .CountAsync(a => a.AppointmentDate.Date == today),

                PendingLabOrders = await _context.LabOrders
                    .CountAsync(l => l.Status == "Pending")
            };
        }
    }
}
