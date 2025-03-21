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
    public class CarDisplacementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarDisplacementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CarDisplacements
        public async Task<IActionResult> Index(int page = 1)
        {
            var applicationDbContext = _context.CarDisplacements.Include(c => c.Car).Include(c => c.Worker);
            return View(await applicationDbContext.GetPagedAsync(page, 5));
        }

        // GET: CarDisplacements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carDisplacement = await _context.CarDisplacements
                .Include(c => c.Car)
                .Include(c => c.Worker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carDisplacement == null)
            {
                return NotFound();
            }

            return View(carDisplacement);
        }

        // GET: CarDisplacements/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Model");
            ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "Id");
            return View();
        }

        // POST: CarDisplacements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarId,WorkerId")] CarDisplacement carDisplacement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carDisplacement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Model", carDisplacement.CarId);
            ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "Id", carDisplacement.WorkerId);
            return View(carDisplacement);
        }

        // GET: CarDisplacements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carDisplacement = await _context.CarDisplacements.FindAsync(id);
            if (carDisplacement == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Model", carDisplacement.CarId);
            ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "Id", carDisplacement.WorkerId);
            return View(carDisplacement);
        }

        // POST: CarDisplacements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarId,WorkerId")] CarDisplacement carDisplacement)
        {
            if (id != carDisplacement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carDisplacement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarDisplacementExists(carDisplacement.Id))
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
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Model", carDisplacement.CarId);
            ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "Id", carDisplacement.WorkerId);
            return View(carDisplacement);
        }

        // GET: CarDisplacements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carDisplacement = await _context.CarDisplacements
                .Include(c => c.Car)
                .Include(c => c.Worker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carDisplacement == null)
            {
                return NotFound();
            }

            return View(carDisplacement);
        }

        // POST: CarDisplacements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carDisplacement = await _context.CarDisplacements.FindAsync(id);
            if (carDisplacement != null)
            {
                _context.CarDisplacements.Remove(carDisplacement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarDisplacementExists(int id)
        {
            return _context.CarDisplacements.Any(e => e.Id == id);
        }
    }
}
