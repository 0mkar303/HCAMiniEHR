using HCAMiniEHR.Models;
using HCAMiniEHR.Models.DTOs;
using HCAMiniEHR.Repositories.Interfaces;

namespace HCAMiniEHR.Services
{
    public class AppointmentService
    {
        private readonly IAppointmentRepository _repo;

        public AppointmentService(IAppointmentRepository repo)
        {
            _repo = repo;
        }

        public async Task AddAsync(Appointment appointment)
        {
            // Business rule
            if (appointment.AppointmentDate.Date < DateTime.Today)
                throw new Exception("Appointment date cannot be in the past");

            await _repo.AddAsync(appointment);
        }

        public Task<List<AppointmentListDto>> GetByPatientAsync(int patientId)
        {
            return _repo.GetByPatientAsync(patientId);
        }
        public async Task CompleteAsync(int appointmentId)
        {
            await _repo.UpdateStatusAsync(appointmentId, "Completed");
        }

        public async Task CancelAsync(int appointmentId)
        {
            await _repo.UpdateStatusAsync(appointmentId, "Cancelled");
        }

    }
}
