using Microsoft.AspNetCore.Mvc;

namespace Product.Controllers
{
    public class ProductsController : Controller
    {
        public class Product { 
            public string Name { get; set; }
            public double price { get; set; }
            public int amount { get; set; }
        }

        List<Product> products = new List<Product>()
        {
            new Product() { Name = "Laptop", price = 999.99, amount = 10 },
            new Product() { Name = "Smartphone", price = 499.99, amount = 25 },
            new Product() { Name = "Tablet", price = 299.99, amount = 15 }
        };  

        public IActionResult Index(int id)
        {
            ViewBag.Name = products[id].Name;
            ViewBag.Price = products[id].price;
            ViewBag.Amount = products[id].amount;

            return View();
        }

        public IActionResult Details(string name, double price)
        {
            ViewBag.Name = name;
            ViewBag.Price = price;
            ViewBag.DiscountedPrice = price > 100 ? price * 0.9 : price;

            return View();
        }
    }
}
