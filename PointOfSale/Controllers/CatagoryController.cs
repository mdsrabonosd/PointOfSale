using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Data;
using PointOfSale.DataModel;

namespace PointOfSale.Controllers
{
    public class CatagoryController : Controller
    {

        private readonly ApplicationDbContext _Dbcontext;
        public CatagoryController(ApplicationDbContext dbcontext)
        {
            _Dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CatagoryCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CatagoryCreate(Catagory obj)
        {
            _Dbcontext.Catagories.Add(obj);
            _Dbcontext.SaveChanges();
            return View(obj);
        }
    }
}
