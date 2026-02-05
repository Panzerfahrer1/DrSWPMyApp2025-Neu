using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VisitCounterMiddleware.Models;
using VisitCounterMiddleware.Service;

namespace VisitCounterMiddleware.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRegisterService _service;

        public HomeController(IRegisterService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            _service.RegisterVisit();
            return View();
        }
    }
}
