using Microsoft.AspNetCore.Mvc;

namespace PointOfSale.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CustomerCreate()
        {
            return View();
        }
        public IActionResult CustomerList()
        {
            return View();
        }
    }
}
