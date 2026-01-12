using HCAMiniEHR.Models;
using HCAMiniEHR.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HCAMiniEHR.Pages.LabOrders
{
    public class IndexModel : PageModel
    {
        private readonly LabOrderService _service;

        public IndexModel(LabOrderService service)
        {
            _service = service;
        }

        public List<LabOrder> LabOrders { get; set; }
        public int AppointmentId { get; set; }

        public async Task OnGetAsync(int appointmentId)
        {
            AppointmentId = appointmentId;
            LabOrders = await _service.GetByAppointmentAsync(appointmentId);
        }
        public async Task<IActionResult> OnPostCompleteAsync(int labOrderId, int appointmentId)
        {
            await _service.CompleteAsync(labOrderId);
            return RedirectToPage(new { appointmentId });
        }
    }

}
