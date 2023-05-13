﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Security.Claims;

using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Web;
using RecycleDevices.Data;
using RecycleDevices.Models;
using Login.Recover_Password;

namespace RecycleDevices.Controllers
{
    public class logginsController : Controller
    {
        private readonly ApointmentContext _context;
        public User User = new User();
       
        public logginsController(ApointmentContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login([Bind("Id,imail,password")] loggin loggin)
        {
            loggin.password = User.Encriptar(loggin.password);

            if (loggin is not null)
            {
                int id;
                int points;
                var us = await _context.Client.SingleOrDefaultAsync(u => u.email == loggin.imail);
                ///   var rolUs = await _context.rolls.SingleOrDefaultAsync(u => u.Id == us.roll);
                ///   
                if (await VerificCredt(loggin.imail, loggin.password)) {
                    switch (us.roll)
                    {
                        //vista cliente 
                        case 1:
                            id = us.Id;
                            points = (int)us.points;
                            TempData["Id"] = id;
                            TempData["points"] = points;
                            TempData.Keep("Id");
                            TempData.Keep("points");
                            return RedirectToAction("ConsultPoints", "Apointments");
                            break;
                    case 2:

                            id = us.Id;
                            TempData["Id"] = id;
                            return RedirectToAction("AsignedApointment", "Apointments");
                            break; ;
                        break;


                    case 3:
                        //vista Gerente
                        return View();
                        break;
                    default: return View();
                        break;
                }
                }
                else {
                    ModelState.AddModelError(string.Empty, "El email o la contraseña son incorrectos");
                    return View(loggin);
                }
               

            }

            return View("~/Views/Apointments/Create.cshtml");
        }


        public async Task<bool> VerificCredt(string email, string password)
        {
            var user = await _context.Client.SingleOrDefaultAsync(u => u.email == email);

            if (user == null)
            {
                // No se encontró un usuario con el correo electrónico proporcionado
                return false;
            }
            else
            {
                if (user.password == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        [HttpGet]
    public IActionResult Recover()
    {
        return View();
    }

        [HttpPost]
        public async Task<IActionResult> Recover(loggin model)
        {
            // Aquí irá la lógica para cambiar la contraseña
            // Puedes acceder al correo electrónico y la nueva contraseña a través de model.imail y model.password
            RecPassword rec = new RecPassword();
            TokensController to = new TokensController(_context);
            Token token = new Token();
          
            var us = await _context.Client.SingleOrDefaultAsync(u => u.email == model.imail);
            if (us is not null)
            {
                // Generar un token aleatorio de 32 bytes
                byte[] tokenBytes = new byte[32];
                using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
                {
                    rng.GetBytes(tokenBytes);

                }
                // Codificar el token como una cadena Base64
                string tok = Convert.ToBase64String(tokenBytes);
                token.id_user = us.Id;
                token.finicio = DateTime.Now;
                token.ffin = DateTime.Now.AddMinutes(10);
                to.Recover(token);
                rec.enviarmail(us.email);
                int userActive = us.Id; 
                TempData["UserActive"] = userActive;
                return RedirectToAction("PassworRec", "loggins");
                //return View("~/Views/loggins/PassworRec.cshtml");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "El email es incorrecto");
                return View(model);
            }

        }
        public async Task<IActionResult> PassworRec(User recover)
        {
            Token touk = new Token();
            UsersController user = new UsersController(_context);
            DateTime fechaAct = DateTime.Now;
            int userActive = (int)TempData["UserActive"];
            var tok = await _context.Tokens.SingleOrDefaultAsync(u => u.id_user == userActive);
            if (tok == null) { return View("~/Views/loggins/ExLimit.cshtml"); }
            else
            {
                if (fechaAct > tok.ffin)
                {
                    return View("~/Views/loggins/ExLimit.cshtml");
                }
                else
                {
                    return View("~/Views/loggins/Login.cshtml");
                }
            }
        }
        
    }
}
   

