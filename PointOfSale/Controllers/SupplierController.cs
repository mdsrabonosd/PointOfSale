using Microsoft.AspNetCore.Mvc;

namespace PointOfSale.Controllers
{
    public class SupplierController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SupplierCreate()
        {
            return View();
        }
        public IActionResult SupplierList()
        {
            return View();
        }
    }
}
