using HCAMiniEHR.Models;
using HCAMiniEHR.Models.DTOs;

namespace HCAMiniEHR.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        // LIST
        Task<List<AppointmentListDto>> GetByPatientAsync(int patientId);

        // ADD
        Task AddAsync(Appointment appointment);
        //Update Appointment Status
        Task UpdateStatusAsync(int appointmentId, string status);

    }
}
