using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Data;

namespace KooliProjekt.Controllers
{
    public class RepairsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RepairsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Repairs
        public async Task<IActionResult> Index(int page = 1)
        {
            var applicationDbContext = _context.Repairs.Include(r => r.Car).Include(r => r.Worker);
            return View(await applicationDbContext.GetPagedAsync(page, 5));
        }

        // GET: Repairs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repair = await _context.Repairs
                .Include(r => r.Car)
                .Include(r => r.Worker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repair == null)
            {
                return NotFound();
            }

            return View(repair);
        }

        // GET: Repairs/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Model");
            ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "Id");
            return View();
        }

        // POST: Repairs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarId,WorkerId")] Repair repair)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repair);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Model", repair.CarId);
            ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "Id", repair.WorkerId);
            return View(repair);
        }

        // GET: Repairs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repair = await _context.Repairs.FindAsync(id);
            if (repair == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Model", repair.CarId);
            ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "Id", repair.WorkerId);
            return View(repair);
        }

        // POST: Repairs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarId,WorkerId")] Repair repair)
        {
            if (id != repair.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repair);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepairExists(repair.Id))
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
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Model", repair.CarId);
            ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "Id", repair.WorkerId);
            return View(repair);
        }

        // GET: Repairs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repair = await _context.Repairs
                .Include(r => r.Car)
                .Include(r => r.Worker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repair == null)
            {
                return NotFound();
            }

            return View(repair);
        }

        // POST: Repairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repair = await _context.Repairs.FindAsync(id);
            if (repair != null)
            {
                _context.Repairs.Remove(repair);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepairExists(int id)
        {
            return _context.Repairs.Any(e => e.Id == id);
        }
    }
}
