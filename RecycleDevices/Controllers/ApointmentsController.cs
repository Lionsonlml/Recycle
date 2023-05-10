using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecycleDevices.Data;
using RecycleDevices.Models;

namespace RecycleDevices.Controllers
{
    public class ApointmentsController : Controller
    {
        private readonly ApointmentContext _context;

        public ApointmentsController(ApointmentContext context)
        {
            _context = context;
        }


        public ActionResult CrearOtraEntidad()
        {
            return RedirectToAction("Create", "Packages");
        }

        // GET: Apointments
        public async Task<IActionResult> Index()
        {
              return _context.Apointment != null ? 
                          View(await _context.Apointment.ToListAsync()) :
                          Problem("Entity set 'ApointmentContext.Apointment'  is null.");
        }

        // GET: Apointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Apointment == null)
            {
                return NotFound();
            }

            var apointment = await _context.Apointment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apointment == null)
            {
                return NotFound();
            }

            return View(apointment);
        }

        // GET: Apointments/Create
        public IActionResult Create()
        {
            ViewBag.Categorias = new SelectList(_context.Product, "Id", "Name");

            return View();
        }

        // POST: Apointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserID,DeliveryID,Country,Departament,Municipality,Address,Date,Description,ProductCategoryID")] Apointment apointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(apointment);
        }

        // GET: Apointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Apointment == null)
            {
                return NotFound();
            }

            var apointment = await _context.Apointment.FindAsync(id);
            if (apointment == null)
            {
                return NotFound();
            }
            return View(apointment);
        }

        // POST: Apointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserID,DeliveryID,Country,Departament,Municipality,Address,Date,Description,ProductCategoryID")] Apointment apointment)
        {
            if (id != apointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApointmentExists(apointment.Id))
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
            return View(apointment);
        }

        // GET: Apointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Apointment == null)
            {
                return NotFound();
            }

            var apointment = await _context.Apointment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apointment == null)
            {
                return NotFound();
            }

            return View(apointment);
        }

        // POST: Apointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Apointment == null)
            {
                return Problem("Entity set 'ApointmentContext.Apointment'  is null.");
            }
            var apointment = await _context.Apointment.FindAsync(id);
            if (apointment != null)
            {
                _context.Apointment.Remove(apointment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApointmentExists(int id)
        {
          return (_context.Apointment?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
