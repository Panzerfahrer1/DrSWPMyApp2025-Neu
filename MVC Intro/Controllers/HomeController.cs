using Microsoft.AspNetCore.Mvc;
using MVC_Intro.Models;
using System.Diagnostics;

namespace MVC_Intro.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        public IActionResult About(string name) {
            //ViewData arbeitet intern mit Dict
            //Es ist immer nur für die Request gültig. Mache ich eine Neue ist es weg
            ViewBag.name = name; //Arbeitet intern mit Viewdata
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
