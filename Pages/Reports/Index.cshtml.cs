using HCAMiniEHR.DTOs;
using HCAMiniEHR.Models.DTOs;
using HCAMiniEHR.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HCAMiniEHR.Pages.Reports
{
    public class IndexModel : PageModel
    {
        private readonly ReportService _service;

        public IndexModel(ReportService service)
        {
            _service = service;
        }

        public List<PendingLabOrderDto> PendingLabOrders { get; set; }
        public List<PatientWithoutFollowUpDto> PatientsWithoutFollowUp { get; set; }
        public List<DoctorProductivityDto> DoctorProductivity { get; set; }

        public async Task OnGetAsync()
        {
            PendingLabOrders = await _service.GetPendingLabOrdersAsync();
            PatientsWithoutFollowUp = await _service.GetPatientsWithoutFollowUpAsync();
            DoctorProductivity = await _service.GetDoctorProductivityAsync();
        }
    }
}
