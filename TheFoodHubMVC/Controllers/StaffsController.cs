using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheFoodHubMVC.Data;
using TheFoodHubMVC.Models;

namespace TheFoodHubMVC.Controllers
{
    [Authorize(Policy = "AdminPages")]
    public class StaffsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public StaffsController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        // GET: StaffsController

        public async Task<ActionResult> Index()
        {
            var users = await _userManager.GetUsersInRoleAsync("Admin");
            return View(users);
        }

        // GET: StaffsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StaffsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StaffsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StaffsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StaffsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StaffsController/Delete/5
        public async Task<ActionResult> Delete(Guid id)

        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            return View(user);
        }

        // POST: StaffsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, IFormCollection collection)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
               await _userManager.DeleteAsync(user);

            }
            return RedirectToAction(nameof(Index));
        }
    }
}
