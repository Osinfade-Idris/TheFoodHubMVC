using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TheFoodHubMVC.Controllers
{
    public class DashboardController : Controller
    {
        [Authorize]

        public IActionResult Index()
        {
            return View();
        }
    }
}
