using HCAMiniEHR.Models.DTOs;
using HCAMiniEHR.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HCAMiniEHR.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DashboardService _service;

        public IndexModel(DashboardService service)
        {
            _service = service;
        }

        public DashboardDto Dashboard { get; set; }

        public async Task OnGetAsync()
        {
            Dashboard = await _service.GetDashboardDataAsync();
        }
    }
}
