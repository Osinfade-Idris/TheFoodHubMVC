using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheFoodHubMVC.Models;

namespace TheFoodHubMVC.Controllers
{
    public class DashboardData : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DashboardData(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ActionResult> Index()
        {
            var staffcount = await _userManager.Users.CountAsync();
            TempData["staffcount"] = staffcount;
            return View();
        }
    }
}
