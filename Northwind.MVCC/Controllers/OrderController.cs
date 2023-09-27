using Microsoft.AspNetCore.Mvc;

namespace Northwind.MVC.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
