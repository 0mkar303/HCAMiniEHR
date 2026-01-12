using HCAMiniEHR.Models;
using HCAMiniEHR.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HCAMiniEHR.Pages.LabOrders
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly LabOrderService _service;

        public CreateModel(LabOrderService service)
        {
            _service = service;
        }

        [BindProperty]
        public LabOrder LabOrder { get; set; }

        // 🔥 Dropdown list
        public SelectList TestList { get; set; }

        public void OnGet(int appointmentId)
        {
            LabOrder = new LabOrder
            {
                AppointmentId = appointmentId
            };

            LoadTests();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                LoadTests(); // 🔑 required on postback
                return Page();
            }

            await _service.AddAsync(LabOrder);

            return RedirectToPage(
                "Index",
                new { appointmentId = LabOrder.AppointmentId });
        }

        // 🔹 Centralized test list
        private void LoadTests()
        {
            TestList = new SelectList(new[]
            {
                "Complete Blood Count (CBC)",
                "Blood Sugar (FBS)",
                "Lipid Profile",
                "Liver Function Test (LFT)",
                "Kidney Function Test (KFT)",
                "Thyroid Profile (TSH)",
                "Urine Routine",
                "X-Ray",
                "ECG",
                "MRI Scan"
            });
        }
    }
}
