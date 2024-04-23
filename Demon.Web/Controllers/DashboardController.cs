using Demon.Application.Services.Implementation;
using Demon.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Demon.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;
        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetTotalBookingRadialChartDataAsync()
        {
            return Json(await _dashboardService.GetTotalBookingRadialChartData());
        }
        public async Task<IActionResult> GetRegisteredUserChartDataAsync()
        {
            return Json(await _dashboardService.GetRegisteredUserChartData());
        }
        public async Task<IActionResult> GetRevenueChartDataAsync()
        {
            return Json(await _dashboardService.GetRevenueChartData());

        }
        public async Task<IActionResult> GetBookingPieChartDataAsync()
        {

            return Json(await _dashboardService.GetBookingPieChartData());
        }
        public async Task<IActionResult> GetMemberAndBookingLineChartData()
        {
            return Json(await _dashboardService.GetMemberAndBookingLineChartData());

        }


    }
}
