using HCAMiniEHR.Models;
using HCAMiniEHR.Services;
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

        public List<Appointment> Appointments { get; set; }
        public int PatientId { get; set; }

        public async Task OnGetAsync(int patientId)
        {
            PatientId = patientId;
            Appointments = await _service.GetByPatientAsync(patientId);
        }
    }
}
