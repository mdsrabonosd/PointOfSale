using Microsoft.AspNetCore.Mvc;

namespace PointOfSale.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
