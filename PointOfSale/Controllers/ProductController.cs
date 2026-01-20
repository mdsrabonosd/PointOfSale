using Microsoft.AspNetCore.Mvc;
using PointOfSale.Data;
using PointOfSale.DataModel;

namespace PointOfSale.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _Dbcontext;
        public ProductController(ApplicationDbContext dbcontext)
        {
            _Dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            var data = _Dbcontext.Products.Add(obj);
            _Dbcontext.SaveChanges();

            return View(obj);
        }
    }
}
