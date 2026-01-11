using HCAMiniEHR.DTOs;
using HCAMiniEHR.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HCAMiniEHR.Pages.Reports
{
    public class PendingLabs : PageModel
    {
        private readonly ReportService _service;

        public PendingLabs(ReportService service)
        {
            _service = service;
        }

        public List<PendingLabOrderDto> Report { get; set; }

        public async Task OnGetAsync()
        {
            Report = await _service.GetPendingLabOrdersAsync();
        }
    }
}
