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
            return RedirectToAction("SupplierList");
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
            var datalist=DBContext.suppliers.FirstOrDefault(x=>x.Id==id);
            if (datalist == null)
            {
                return NotFound();
            }
            else
            {
                var data = new SupplierVM
                {
                    Id = datalist.Id,
                    Name = datalist.Name,
                    Email = datalist.Email,
                    Phone = datalist.Phone

                };
                return View(data);
            }
           
        }
        [HttpPost]
        public IActionResult Edit(SupplierVM obj)
        {
             if (!ModelState.IsValid)
            {
                return View(obj);
            }
            var data = DBContext.suppliers.FirstOrDefault(x => x.Id == obj.Id);

            if (data == null)
            {
                return NotFound();
            }
            data.Id = obj.Id;
            data.Name = obj.Name;
            data.Email = obj.Email;
            data.Phone = obj.Phone;

            DBContext.SaveChanges();

            return RedirectToAction("SupplierList");
        }
    }
}