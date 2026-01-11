using Microsoft.AspNetCore.Mvc.RazorPages;
using HCAMiniEHR.Data;
using HCAMiniEHR.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace HCAMiniEHR.Pages.Reports
{
    public class PatientsWithoutFollowUpModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public PatientsWithoutFollowUpModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Patient> Patients { get; set; }

        public void OnGet()
        {
            // WHERE + ANY
            Patients = _context.Patients
                .Where(p => !p.Appointments.Any(
                    a => a.AppointmentDate > DateTime.Now))
                .ToList();
        }
    }
}
