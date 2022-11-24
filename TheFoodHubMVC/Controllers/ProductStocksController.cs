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
    public class ProductStocksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductStocksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductStocks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductStocks.Include(p => p.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProductStocks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.ProductStocks == null)
            {
                return NotFound();
            }

            var productStock = await _context.ProductStocks
                .Include(p => p.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ProductStockId == id);
            if (productStock == null)
            {
                return NotFound();
            }

            return View(productStock);
        }

        // GET: ProductStocks/Create
        public IActionResult Create()
        {
            ViewData["StaffId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: ProductStocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductStockId,StaffId,Quantity")] ProductStock productStock)
        {
            if (ModelState.IsValid)
            {
                productStock.ProductStockId = Guid.NewGuid();
                _context.Add(productStock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StaffId"] = new SelectList(_context.Users, "Id", "Id", productStock.StaffId);
            return View(productStock);
        }

        // GET: ProductStocks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.ProductStocks == null)
            {
                return NotFound();
            }

            var productStock = await _context.ProductStocks.FindAsync(id);
            if (productStock == null)
            {
                return NotFound();
            }
            ViewData["StaffId"] = new SelectList(_context.Users, "Id", "Id", productStock.StaffId);
            return View(productStock);
        }

        // POST: ProductStocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProductStockId,StaffId,Quantity")] ProductStock productStock)
        {
            if (id != productStock.ProductStockId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productStock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductStockExists(productStock.ProductStockId))
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
            ViewData["StaffId"] = new SelectList(_context.Users, "Id", "Id", productStock.StaffId);
            return View(productStock);
        }

        // GET: ProductStocks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.ProductStocks == null)
            {
                return NotFound();
            }

            var productStock = await _context.ProductStocks
                .Include(p => p.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ProductStockId == id);
            if (productStock == null)
            {
                return NotFound();
            }

            return View(productStock);
        }

        // POST: ProductStocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.ProductStocks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProductStocks'  is null.");
            }
            var productStock = await _context.ProductStocks.FindAsync(id);
            if (productStock != null)
            {
                _context.ProductStocks.Remove(productStock);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductStockExists(Guid id)
        {
          return _context.ProductStocks.Any(e => e.ProductStockId == id);
        }
    }
}
