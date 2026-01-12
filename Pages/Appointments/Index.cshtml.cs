using HCAMiniEHR.Models.DTOs;
using HCAMiniEHR.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HCAMiniEHR.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly AppointmentService _service;

        public IndexModel(AppointmentService service)
        {
            _service = service;
        }

        public List<AppointmentListDto> Appointments { get; set; }
        public int PatientId { get; set; }

        public async Task OnGetAsync(int patientId)
        {
            PatientId = patientId;
            Appointments = await _service.GetByPatientAsync(patientId);
        }
        public async Task<IActionResult> OnPostCompleteAsync(int appointmentId, int patientId)
        {
            await _service.CompleteAsync(appointmentId);
            return RedirectToPage(new { patientId });
        }

        public async Task<IActionResult> OnPostCancelAsync(int appointmentId, int patientId)
        {
            await _service.CancelAsync(appointmentId);
            return RedirectToPage(new { patientId });
        }

    }
}
