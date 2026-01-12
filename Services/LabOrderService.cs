using HCAMiniEHR.Models;
using HCAMiniEHR.Repositories.Interfaces;

namespace HCAMiniEHR.Services
{
    public class LabOrderService
    {
        private readonly ILabOrderRepository _repo;

        public LabOrderService(ILabOrderRepository repo)
        {
            _repo = repo;
        }

        public Task AddAsync(LabOrder labOrder)
        {
            return _repo.AddAsync(labOrder);
        }

        public Task<List<LabOrder>> GetByAppointmentAsync(int appointmentId)
        {
            return _repo.GetByAppointmentAsync(appointmentId);
        }
        public Task CompleteAsync(int labOrderId)
        {
            return _repo.UpdateStatusAsync(labOrderId, "Completed");
        }
    }

}
