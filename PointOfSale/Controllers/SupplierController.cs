using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Data;
using PointOfSale.DataModel;
using PointOfSale.ViewModel;

namespace PointOfSale.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ApplicationDbContext DBContext;

        public SupplierController(ApplicationDbContext dbcontext)
        {
            DBContext = dbcontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SupplierCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SupplierCreate(SupplierVM obj)
        {
            if (ModelState.IsValid)
            {
                var data = new Supplier
                {
                    Name = obj.Name,
                    Email = obj.Email,
                    Phone = obj.Phone
                };

                DBContext.suppliers.Add(data);
                DBContext.SaveChanges();

            }
            return RedirectToAction("SupplierCreate");
        }

        public IActionResult SupplierList()
        {
            var datalist = DBContext.suppliers.Select(x => new SupplierVM
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Phone = x.Phone
            }).ToList();

            return View(datalist);
        }
        //var data = DbContext.suppliers.ToList();
        //return view(data);

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var datalist = DBContext.suppliers.FirstOrDefault(x => x.Id == id);
            if (datalist == null)
            {
                return NotFound();
            }
            var data = new SupplierVM
            {
                Id=datalist.Id,
                Name=datalist.Name,
                Email=datalist.Email,
                Phone = datalist.Phone
            };
            return View(data);
        }
    }
}