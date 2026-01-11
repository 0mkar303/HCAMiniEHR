using HCAMiniEHR.Models;
using HCAMiniEHR.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HCAMiniEHR.Pages.Appointments
{
    public class CreateModel : PageModel
    {
        private readonly AppointmentService _appointmentService;
        private readonly DoctorService _doctorService;

        public CreateModel(
            AppointmentService appointmentService,
            DoctorService doctorService)
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
        }

        [BindProperty] public int PatientId { get; set; }
        [BindProperty] public int DoctorId { get; set; }
        [BindProperty] public DateTime AppointmentDate { get; set; }
        [BindProperty] public string Status { get; set; }

        public List<Doctor> Doctors { get; set; }

        public async Task OnGetAsync(int patientId)
        {
            PatientId = patientId;
            Doctors = await _doctorService.GetAllAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("PatientId = " + PatientId);

            await _appointmentService.CreateUsingSPAsync(
                PatientId,
                DoctorId,
                AppointmentDate,
                Status
            );

            return RedirectToPage("Index", new { patientId = PatientId });
        }

    }
}
