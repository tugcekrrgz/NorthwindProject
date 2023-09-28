using Microsoft.AspNetCore.Mvc;

namespace Northwind.MVC.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
