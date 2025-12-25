using Microsoft.AspNetCore.Mvc;

namespace MVC_Intro.Controllers {
    public class UserController : Controller {
        public IActionResult Profile(string name, int age, string email) {
            ViewBag.name = name;
            ViewBag.age = age;
            ViewBag.email = email;

            return View();
        }
    }
}
