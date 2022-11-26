using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheFoodHubMVC.Data;
using TheFoodHubMVC.Models;

namespace TheFoodHubMVC.Controllers
{
    public class AllProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AllProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AllProducts
        public async Task<IActionResult> Index()
        {
              return View(await _context.AllProducts.ToListAsync());
        }

        // GET: AllProducts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.AllProducts == null)
            {
                return NotFound();
            }

            var allProducts = await _context.AllProducts
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (allProducts == null)
            {
                return NotFound();
            }

            return View(allProducts);
        }

        // GET: AllProducts/Create
        public IActionResult Create()
        {
            ViewData["Categories"] = _context.ProductCategories.ToList();
            ViewData["Statuses"] = _context.Statuses.ToList();
            return View();
        }

        // POST: AllProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,CategoryId,ProductName,Price,Quantity,StatusId,ProductPicture")] AllProducts allProducts)
        {
            if (ModelState.IsValid)
            {
                allProducts.ProductId = Guid.NewGuid();
                _context.Add(allProducts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allProducts);
        }

        // GET: AllProducts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.AllProducts == null)
            {
                return NotFound();
            }

            var allProducts = await _context.AllProducts.FindAsync(id);
            if (allProducts == null)
            {
                return NotFound();
            }
            return View(allProducts);
        }

        // POST: AllProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProductId,CategoryId,ProductName,Price,Quantity,StatusId,ProductPicture")] AllProducts allProducts)
        {
            if (id != allProducts.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allProducts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllProductsExists(allProducts.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(allProducts);
        }

        // GET: AllProducts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.AllProducts == null)
            {
                return NotFound();
            }

            var allProducts = await _context.AllProducts
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (allProducts == null)
            {
                return NotFound();
            }

            return View(allProducts);
        }

        // POST: AllProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.AllProducts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AllProducts'  is null.");
            }
            var allProducts = await _context.AllProducts.FindAsync(id);
            if (allProducts != null)
            {
                _context.AllProducts.Remove(allProducts);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllProductsExists(Guid id)
        {
          return _context.AllProducts.Any(e => e.ProductId == id);
        }
    }
}
