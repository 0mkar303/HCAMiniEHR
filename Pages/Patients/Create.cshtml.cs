using HCAMiniEHR.Models;
using HCAMiniEHR.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HCAMiniEHR.Pages.Patients
{
    public class CreateModel : PageModel
    {
        private readonly PatientService _service;

        public CreateModel(PatientService service)
        {
            _service = service;
        }

        [BindProperty]
        public Patient Patient { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("POST HIT");
           

            await _service.AddAsync(Patient);
            return RedirectToPage("Index");
        }
    }
}
