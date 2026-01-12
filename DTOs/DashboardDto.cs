namespace HCAMiniEHR.Models.DTOs
{
    public class DashboardDto
    {
        public int TotalPatients { get; set; }
        public int TotalAppointments { get; set; }
        public int TodayAppointments { get; set; }
        public int PendingLabOrders { get; set; }
    }
}
