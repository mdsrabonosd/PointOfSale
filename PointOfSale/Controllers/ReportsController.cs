using Microsoft.AspNetCore.Mvc;

namespace PointOfSale.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
