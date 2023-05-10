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
    public class TokensController : Controller
    {
        private readonly ApointmentContext _context;

        public TokensController(ApointmentContext context)
        {
            _context = context;
        }

        // GET: Tokens
        public async Task<IActionResult> Index()
        {
            var loginContext = _context.Tokens.Include(t => t.USUARIO);
            return View(await loginContext.ToListAsync());
        }

        // GET: Tokens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tokens == null)
            {
                return NotFound();
            }

            var token = await _context.Tokens
                .Include(t => t.USUARIO)
                .FirstOrDefaultAsync(m => m.id_token == id);
            if (token == null)
            {
                return NotFound();
            }

            return View(token);
        }

        // GET: Tokens/Create
        public IActionResult Create()
        {
            ViewData["id_user"] = new SelectList(_context.Client, "Id", "Id");
            return View();
        }

        // POST: Tokens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Recover([Bind("id_token,id_user,finicio,ffin,tactivo")] Token token)
        {
            if (ModelState.IsValid)
            {
                _context.Add(token);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_user"] = new SelectList(_context.Client, "Id", "Id", token.id_user);
            return View(token);
        }

        // GET: Tokens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tokens == null)
            {
                return NotFound();
            }

            var token = await _context.Tokens.FindAsync(id);
            if (token == null)
            {
                return NotFound();
            }
            ViewData["id_user"] = new SelectList(_context.Client, "Id", "Id", token.id_user);
            return View(token);
        }

        // POST: Tokens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_token,id_user,finicio,ffin,tactivo")] Token token)
        {
            if (id != token.id_token)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(token);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TokenExists(token.id_token))
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
            ViewData["id_user"] = new SelectList(_context.Client, "Id", "Id", token.id_user);
            return View(token);
        }

        // GET: Tokens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tokens == null)
            {
                return NotFound();
            }

            var token = await _context.Tokens
                .Include(t => t.USUARIO)
                .FirstOrDefaultAsync(m => m.id_token == id);
            if (token == null)
            {
                return NotFound();
            }

            return View(token);
        }

        // POST: Tokens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tokens == null)
            {
                return Problem("Entity set 'LoginContext.Tokens'  is null.");
            }
            var token = await _context.Tokens.FindAsync(id);
            if (token != null)
            {
                _context.Tokens.Remove(token);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TokenExists(int id)
        {
          return (_context.Tokens?.Any(e => e.id_token == id)).GetValueOrDefault();
        }
    }
}
