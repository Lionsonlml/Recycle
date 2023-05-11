using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDDomiciliarioVehiculo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecycleDevices.Data;

namespace CRUDDomiciliarioVehiculo.Controllers
{
    public class DomiciliariosController : Controller
    {
        private readonly ApointmentContext _context;

        public DomiciliariosController(ApointmentContext context)
        {
            _context = context;
        }

        // GET: Domiciliarios
        public async Task<IActionResult> Index()
        {
              return _context.Domiciliarios != null ? 
                          View(await _context.Domiciliarios.ToListAsync()) :
                          Problem("Entity set 'CRUDDomVehiculo_Context.Domiciliarios'  is null.");
        }

        // GET: Domiciliarios/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Domiciliarios == null)
            {
                return NotFound();
            }

            var domiciliario = await _context.Domiciliarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (domiciliario == null)
            {
                return NotFound();
            }

            return View(domiciliario);
        }

        // GET: Domiciliarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Domiciliarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdDom,TypeId,Name,LastName,Email,password,Day,HourInitial,HourEnd,Rol")] Domiciliario domiciliario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(domiciliario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(domiciliario);
        }

        // GET: Domiciliarios/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Domiciliarios == null)
            {
                return NotFound();
            }

            var domiciliario = await _context.Domiciliarios.FindAsync(id);
            if (domiciliario == null)
            {
                return NotFound();
            }
            return View(domiciliario);
        }

        // POST: Domiciliarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,IdDom,TypeId,Name,LastName,Email,password,Day,HourInitial,HourEnd,Rol")] Domiciliario domiciliario)
        {
            if (id != domiciliario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(domiciliario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DomiciliarioExists(domiciliario.Id))
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
            return View(domiciliario);
        }

        // GET: Domiciliarios/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Domiciliarios == null)
            {
                return NotFound();
            }

            var domiciliario = await _context.Domiciliarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (domiciliario == null)
            {
                return NotFound();
            }

            return View(domiciliario);
        }

        // POST: Domiciliarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Domiciliarios == null)
            {
                return Problem("Entity set 'CRUDDomVehiculo_Context.Domiciliarios'  is null.");
            }
            var domiciliario = await _context.Domiciliarios.FindAsync(id);
            if (domiciliario != null)
            {
                _context.Domiciliarios.Remove(domiciliario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DomiciliarioExists(string id)
        {
          return (_context.Domiciliarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
