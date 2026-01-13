using HCAMiniEHR.Models;
using HCAMiniEHR.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HCAMiniEHR.Pages.Patients
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly PatientService _service;

        public DeleteModel(PatientService service)
        {
            _service = service;
        }

        [BindProperty]
        public Patient Patient { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Patient = await _service.GetByIdAsync(id);
            if (Patient == null)
                return RedirectToPage("Index");

            return Page();
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    await _service.DeleteAsync(Patient.PatientId);
        //    return RedirectToPage("Index");
        //}

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _service.DeleteAsync(Patient.PatientId);
                return RedirectToPage("Index");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.Clear(); // ✅ CORRECT PLACE
                // Show business rule error to user
                ModelState.AddModelError(string.Empty, ex.Message);

                // Reload patient so name is available again
                Patient = await _service.GetByIdAsync(Patient.PatientId);

                return Page();
            }
        }

    }
}
