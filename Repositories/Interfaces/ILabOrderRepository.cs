using HCAMiniEHR.Models;

namespace HCAMiniEHR.Repositories.Interfaces
{
    public interface ILabOrderRepository
    {
        Task AddAsync(LabOrder labOrder);
        Task<List<LabOrder>> GetByAppointmentAsync(int appointmentId);
        Task UpdateStatusAsync(int labOrderId, string status);
    }

}
