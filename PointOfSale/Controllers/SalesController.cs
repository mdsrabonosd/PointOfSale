using Microsoft.AspNetCore.Mvc;

namespace PointOfSale.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
