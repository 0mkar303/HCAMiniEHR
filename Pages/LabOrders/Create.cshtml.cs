using HCAMiniEHR.Models;
using HCAMiniEHR.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HCAMiniEHR.Pages.LabOrders
{
    public class CreateModel : PageModel
    {
        private readonly LabOrderService _service;

        public CreateModel(LabOrderService service)
        {
            _service = service;
        }

        [BindProperty]
        public LabOrder LabOrder { get; set; }

        public void OnGet(int appointmentId)
        {
            LabOrder = new LabOrder
            {
                AppointmentId = appointmentId
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _service.AddAsync(LabOrder);

            return RedirectToPage(
                "Index",
                new { appointmentId = LabOrder.AppointmentId });
        }
    }

}
