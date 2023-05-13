using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecycleDevices.Data;
using RecycleDevices.Models;
using Login.Recover_Password;

namespace RecycleDevices.Controllers
{
    public class logginsController : Controller
    {
        private readonly ApointmentContext _context;
        public User User = new User();
        private readonly IHttpContextAccessor _httpContextAccessor;
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
                SessionManager.RemoveSessionValue("IdTable");

                SessionManager.ClearSession();


                var us = await _context.logers.SingleOrDefaultAsync(u => u.email == loggin.imail);
                ///   var rolUs = await _context.rolls.SingleOrDefaultAsync(u => u.Id == us.roll);
                ///   
                if (await VerificCredt(loggin.imail, loggin.password)) {
                    SessionManager.SetSessionValue("IdTable", us.idTable);
                    switch (us.roll)
                    {
                        //vista cliente 
                        case 1:
                           
                            //     HttpContext.Session.SetInt32("Id", us.idTable);
                            return RedirectToAction("Create", "Apointments");
                            break;
                    case 2:

                            //domiciliario
                          
                            return RedirectToAction("AsignedApointment", "Apointments");
                            break; ;
                        break;


                    case 3:
                        // funcionario 
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
                token.code = tok;
                token.id_user = us.Id;
                token.finicio = DateTime.Now;
                token.ffin = DateTime.Now.AddMinutes(10);
                to.Recover(token);
                rec.enviarmail(us.email,token.code);
                int userActive = us.Id; 
             //   TempData["UserActive"] = userActive;
                return RedirectToAction("PassworRec", "loggins");
                //return View("~/Views/loggins/PassworRec.cshtml");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "El email es incorrecto");
                return View(model);
            }

        }
        [HttpGet]
        public IActionResult PassworRec()
        {
      ///      string userActive = TempData["UserActive"].ToString();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PassworRec(Recuperar recover)
        {
            Token touk = new Token();
            UsersController user = new UsersController(_context);
            DateTime fechaAct = DateTime.Now;
            // string userActive = TempData["UserActive"].ToString();
            var tok = await _context.Tokens.SingleOrDefaultAsync(u => u.code == recover.code);

            if (tok is not null)
            {
                if (tok.ffin >= fechaAct)
                {
                    var us = await _context.Client.SingleOrDefaultAsync(u => u.Id == tok.id_user);
                    recover.newPassword = User.Encriptar(recover.newPassword);
                    if (recover.newPassword != us.password)
                    {
                        us.password = recover.newPassword;
                        _context.Client.Update(us);
                        await _context.SaveChangesAsync();
                        return View("~/Views/Home/Index.cshtml");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Las contraseñas no pueden ser Iguales");
                        return View(recover);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "La fecha de recuperacion de contraseña ya expiró");
                    return View(recover);
                }


            }
            else
            {
                ModelState.AddModelError(string.Empty, "El codigo es invalido");
                return View(recover);
            }

            //if (tok == null) { return View("~/Views/Hokme/Index.cshtml"); }
            //else
            //{
            //    if (fechaAct > tok.ffin)
            //    {
            //        return View("~/Views/loggins/ExLimit.cshtml");
            //    }
            //    else
            //    {
            //        return View("~/Views/loggins/Login.cshtml");
            //    }
            //}
        }
       

    }


}

public static class SessionManager
{
    private static Dictionary<string, object> _sessionData = new Dictionary<string, object>();

    public static void SetSessionValue(string key, object value)
    {
        _sessionData[key] = value;
    }

    public static object GetSessionValue(string key)
    {
        object value;
        _sessionData.TryGetValue(key, out value);
        return value;
    }
    public static void RemoveSessionValue(string key)
    {
        _sessionData.Remove(key);
    }
    public static void ClearSession()
    {
        _sessionData = new Dictionary<string, object>();
    }
}
