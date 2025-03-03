using AlexProject.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Serializer;

namespace WebApplication2.WebApp.WebControllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login() { return View(); }
    }
}
