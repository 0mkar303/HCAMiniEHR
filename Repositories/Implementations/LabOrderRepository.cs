using HCAMiniEHR.Data;
using HCAMiniEHR.Models;
using HCAMiniEHR.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HCAMiniEHR.Repositories.Implementations
{
    public class LabOrderRepository : ILabOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public LabOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(LabOrder labOrder)
        {
            await _context.Database.ExecuteSqlRawAsync(
                @"EXEC Healthcare.CreateLabOrder
              @AppointmentId={0},
              @TestName={1}",
                labOrder.AppointmentId,
                labOrder.TestName
            );
        }

        public async Task<List<LabOrder>> GetByAppointmentAsync(int appointmentId)
        {
            return await _context.LabOrders
                .FromSqlRaw(
                    "EXEC Healthcare.GetLabOrdersByAppointment @AppointmentId={0}",
                    appointmentId)
                .ToListAsync();
        }
        public async Task UpdateStatusAsync(int labOrderId, string status)
        {
            await _context.Database.ExecuteSqlRawAsync(
                @"EXEC Healthcare.UpdateLabOrderStatus
          @LabOrderId = {0},
          @Status = {1}",
                labOrderId,
                status
            );
        }

    }

}
