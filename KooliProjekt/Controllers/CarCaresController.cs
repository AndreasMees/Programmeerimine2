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
    public class CarCaresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarCaresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CarCares
        public async Task<IActionResult> Index(int page = 1)
        {
            var applicationDbContext = _context.CarCares.Include(c => c.Car).Include(c => c.Worker);
            return View(await applicationDbContext.GetPagedAsync(page, 5));
        }

        // GET: CarCares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carCare = await _context.CarCares
                .Include(c => c.Car)
                .Include(c => c.Worker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carCare == null)
            {
                return NotFound();
            }

            return View(carCare);
        }

        // GET: CarCares/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Model");
            ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "Id");
            return View();
        }

        // POST: CarCares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarId,WorkerId")] CarCare carCare)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carCare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Model", carCare.CarId);
            ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "Id", carCare.WorkerId);
            return View(carCare);
        }

        // GET: CarCares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carCare = await _context.CarCares.FindAsync(id);
            if (carCare == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Model", carCare.CarId);
            ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "Id", carCare.WorkerId);
            return View(carCare);
        }

        // POST: CarCares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarId,WorkerId")] CarCare carCare)
        {
            if (id != carCare.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carCare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarCareExists(carCare.Id))
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
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Model", carCare.CarId);
            ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "Id", carCare.WorkerId);
            return View(carCare);
        }

        // GET: CarCares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carCare = await _context.CarCares
                .Include(c => c.Car)
                .Include(c => c.Worker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carCare == null)
            {
                return NotFound();
            }

            return View(carCare);
        }

        // POST: CarCares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carCare = await _context.CarCares.FindAsync(id);
            if (carCare != null)
            {
                _context.CarCares.Remove(carCare);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarCareExists(int id)
        {
            return _context.CarCares.Any(e => e.Id == id);
        }
    }
}
