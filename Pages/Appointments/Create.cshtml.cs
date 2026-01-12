using HCAMiniEHR.Data;
using HCAMiniEHR.Models;
using HCAMiniEHR.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HCAMiniEHR.Pages.Appointments
{
    public class CreateModel : PageModel
    {
        private readonly AppointmentService _service;
        private readonly ApplicationDbContext _context;

        public CreateModel(
            AppointmentService service,
            ApplicationDbContext context)
        {
            _service = service;
            _context = context;
        }

        [BindProperty]
        public Appointment Appointment { get; set; }

        public SelectList Doctors { get; set; }

        public void OnGet(int patientId)
        {
            Appointment = new Appointment
            {
                PatientId = patientId
            };

            Doctors = new SelectList(
                _context.Doctors.ToList(),
                "DoctorId",
                "FullName");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Doctors = new SelectList(
                    _context.Doctors, "DoctorId", "FullName");
                return Page();
            }

            await _service.AddAsync(Appointment);

            return RedirectToPage(
                "Index",
                new { patientId = Appointment.PatientId });
        }


    }
}
