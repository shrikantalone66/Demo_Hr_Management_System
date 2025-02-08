using System.Diagnostics;
using Demo_HR_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo_HR_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Aboutus()
        {
            return View();
        }

        public IActionResult Contactus()
        {
            return View();
        }

        
        public IActionResult AdminLogin(string txtUsername,string txtPassword)
        {
            if (txtUsername == "admin" && txtPassword == "super")
            {
                return RedirectToAction("Index" , "Admin");
            }
            else
            {
               ViewBag.Message = "Invalid Username or Password";
            }   

            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
