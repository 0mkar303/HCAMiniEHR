using HCAMiniEHR.Models;
using HCAMiniEHR.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HCAMiniEHR.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private readonly PatientService _service;
        public IndexModel(PatientService service) => _service = service;

        public List<Patient> Patients { get; set; }

        public async Task OnGetAsync()
        {
            Patients = await _service.GetAllAsync();
        }
    }
}
