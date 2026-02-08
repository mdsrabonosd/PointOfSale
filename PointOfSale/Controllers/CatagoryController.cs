using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Data;
using PointOfSale.DataModel;
using PointOfSale.ViewModel;
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
        public IActionResult CatagoryCreate(CatagoryVM obj)
        {
            if (obj == null)
            {
                return NotFound();
            }

            var data = new Catagory();

            data.CatagoryName = obj.CatagoryName;
            data.IsActive = obj.IsActive;

            _Dbcontext.Catagories.Add(data);
            _Dbcontext.SaveChanges();

            return View(obj);
        }
        public IActionResult CatagoryList()
        {
            return View();
        }
    }
}
