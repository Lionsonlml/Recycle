using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
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


        public string GenerateRandomCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task<IActionResult> GenerateCodeAsync(int pointRedeem)
        {

            UsersController us = new UsersController(_context);

            int id = (int)SessionManager.GetSessionValue("IdTable");
            //var us = await _context.Client.SingleOrDefault(u=> u.Id == id); 
            var user = await _context.Client
               .FirstOrDefaultAsync(m => m.Id == id);
            var User = _context.Client.Where(p => p.Id == id).SingleOrDefault();
            var Point = (int)user.points;



            if (User != null)
            {
                User.points = (User.points - pointRedeem) ;

                _context.Update(User);

                _context.SaveChanges();
            }




            var Model = new ConsultPointViewModel()
            {

            CodeDiscount = GenerateRandomCode(8)
        };
            Model.Point = Point;
            return View(Model);
        }

        public async Task<IActionResult> ConsultPointsAsync(int pointRedeem)
        {

            int id = (int)SessionManager.GetSessionValue("IdTable");
            ////var us = await _context.Client.SingleOrDefault(u=> u.Id == id); 
            var user = await _context.Client
               .FirstOrDefaultAsync(m => m.Id == id);
            //var User = _context.Client.Where(p => p.Id == id).SingleOrDefault();
           var Point = (int)user.points;
          

           
            //if (User!= null)
            //{
            //             User.points = (User.points - pointRedeem);

            //    _context.Update(User);

            //    _context.SaveChanges();
            //}

          
            if (id == null || _context.Apointment == null)
            {
                return NotFound();
            }

            var model = new ConsultPointViewModel();
            //.FirstOrDefaultAsync(m => m.Id == id);


            model.Point = Point;
            if (model == null)
            {
                return NotFound();
            }
            // Return the view with the view model
            return View(model);
        }

        public ActionResult CrearOtraEntidad()
        {
            return RedirectToAction("Create", "Packages");
        }
      
        public async Task<IActionResult> AsignedApointment()
        {
            return _context.Apointment != null ?
                        View(await _context.Apointment.ToListAsync()) :
                        Problem("Entity set 'ApointmentContext.Apointment'  is null.");
        }

     
        public async Task<IActionResult> UpdateState(int id)
        {
            int ID = (int)SessionManager.GetSessionValue("IdTable");
         
            var user = await _context.Client
                .FirstOrDefaultAsync(m => m.Id == id);
            var AsignedApointment = _context.Apointment.Where(p => p.Id == id).SingleOrDefault();
            var UserPointAdd = _context.Client.Where(p => p.Id == ID).SingleOrDefault();

            if (AsignedApointment != null)
            {
                AsignedApointment.State = "Completa";
                UserPointAdd.points = UserPointAdd.points + AsignedApointment.Points;

                _context.SaveChanges();
            }

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


            //   var id = (int)TempData["Id"];
            //   var points = (int)TempData["points"];
            int id = (int)SessionManager.GetSessionValue("IdTable");
          
            User us = new User();

            var points = (int)us.points;
            Apointment ap = new Apointment();

                ap.UserID = id;
                ap.Points = points;
                ViewBag.Categorias = new SelectList(_context.Product, "Points", "Name");
            
            if (id == null || _context.Apointment == null)
            {
                return View(ap);
            }

            return View(ap);
        }

        // POST: Apointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserID,DeliveryID,Country,Departament,Municipality,Address,Date,PackageId,ProductCategoryID,State,Points")] Apointment apointment)
        {

            //
            //var user = await _context.Client.FindAsync(id);
            int id = (int)SessionManager.GetSessionValue("IdTable");
            if (ModelState.IsValid)
            {
               apointment.UserID = id;
                apointment.State = "Preparado";
                
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserID,DeliveryID,Country,Departament,Municipality,Address,Date,PackageId,ProductCategoryID,State,Points")] Apointment apointment)
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
