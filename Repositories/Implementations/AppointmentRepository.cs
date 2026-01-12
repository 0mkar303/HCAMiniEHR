using HCAMiniEHR.Data;
using HCAMiniEHR.Models;
using HCAMiniEHR.Models.DTOs;
using HCAMiniEHR.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HCAMiniEHR.Repositories.Implementations
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // ADD APPOINTMENT (Stored Procedure)
        public async Task AddAsync(Appointment appointment)
        {
            await _context.Database.ExecuteSqlRawAsync(
                @"EXEC Healthcare.CreateAppointment
                  @PatientId = {0},
                  @DoctorId = {1},
                  @AppointmentDate = {2}",
                appointment.PatientId,
                appointment.DoctorId,
                appointment.AppointmentDate
            );
        }

        // LIST APPOINTMENTS (Stored Procedure + DTO)
        public async Task<List<AppointmentListDto>> GetByPatientAsync(int patientId)
        {
            return await _context.Set<AppointmentListDto>()
                .FromSqlRaw(
                    "EXEC Healthcare.GetAppointmentsByPatient @PatientId = {0}",
                    patientId)
                .ToListAsync();
        }
        public async Task UpdateStatusAsync(int appointmentId, string status)
        {
            await _context.Database.ExecuteSqlRawAsync(
                @"EXEC Healthcare.UpdateAppointmentStatus
          @AppointmentId = {0},
          @Status = {1}",
                appointmentId,
                status
            );
        }

    }
}
