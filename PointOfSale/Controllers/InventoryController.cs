using Microsoft.AspNetCore.Mvc;

namespace PointOfSale.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
