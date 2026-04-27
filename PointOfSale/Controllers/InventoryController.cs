using Microsoft.AspNetCore.Mvc;

namespace PointOfSale.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult InvoiceCreate()
        {
            return View();
        }
        public IActionResult InvoiceList()
        {
            return View();
        }
        
    }
}
