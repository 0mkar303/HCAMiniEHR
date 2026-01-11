using Microsoft.AspNetCore.Mvc.RazorPages;
using HCAMiniEHR.Data;
using HCAMiniEHR.Models;
using System.Collections.Generic;
using System.Linq;

namespace HCAMiniEHR.Pages.Reports
{
    public class AppointmentsByDateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AppointmentsByDateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Appointment> Appointments { get; set; }

        public void OnGet()
        {
            // ORDER BY
            Appointments = _context.Appointments
                .OrderBy(a => a.AppointmentDate)
                .ToList();
        }
    }
}
