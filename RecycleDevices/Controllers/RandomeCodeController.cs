using Microsoft.AspNetCore.Mvc;

namespace RecycleDevices.Controllers
{
    public class RandomCodeController : Controller
    {
        public IActionResult Index()
        {
            // Generate a random alphanumeric code with a length of 8
            string randomCode = GenerateRandomCode(8);
            ViewBag.Code = randomCode;
            return View();
        }

        private static string GenerateRandomCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
