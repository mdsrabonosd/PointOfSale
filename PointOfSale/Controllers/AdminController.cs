using Microsoft.AspNetCore.Mvc;

namespace PointOfSale.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
