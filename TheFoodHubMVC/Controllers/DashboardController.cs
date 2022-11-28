using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheFoodHubMVC.Data;
using TheFoodHubMVC.Models;

namespace TheFoodHubMVC.Controllers
{
    public class DashboardController : Controller
    {
        
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        public DashboardController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            var staffcount = await _userManager.Users.CountAsync();
            TempData["staffcount"] = staffcount - 1;

            var categorycount = await _context.ProductCategories.CountAsync();
            TempData["categorycount"] = categorycount;

            var allproduct = await _context.AllProducts.CountAsync();
            TempData["allproduct"] = allproduct;

            return View();
        }
    }
}
