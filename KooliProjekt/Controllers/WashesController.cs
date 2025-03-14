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
    public class WashesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WashesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Washes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Washes.Include(w => w.Car).Include(w => w.Worker);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Washes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wash = await _context.Washes
                .Include(w => w.Car)
                .Include(w => w.Worker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wash == null)
            {
                return NotFound();
            }

            return View(wash);
        }

        // GET: Washes/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Model");
            ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "Id");
            return View();
        }

        // POST: Washes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarId,WorkerId")] Wash wash)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wash);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Model", wash.CarId);
            ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "Id", wash.WorkerId);
            return View(wash);
        }

        // GET: Washes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wash = await _context.Washes.FindAsync(id);
            if (wash == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Model", wash.CarId);
            ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "Id", wash.WorkerId);
            return View(wash);
        }

        // POST: Washes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarId,WorkerId")] Wash wash)
        {
            if (id != wash.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wash);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WashExists(wash.Id))
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
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Model", wash.CarId);
            ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "Id", wash.WorkerId);
            return View(wash);
        }

        // GET: Washes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wash = await _context.Washes
                .Include(w => w.Car)
                .Include(w => w.Worker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wash == null)
            {
                return NotFound();
            }

            return View(wash);
        }

        // POST: Washes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wash = await _context.Washes.FindAsync(id);
            if (wash != null)
            {
                _context.Washes.Remove(wash);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WashExists(int id)
        {
            return _context.Washes.Any(e => e.Id == id);
        }
    }
}
