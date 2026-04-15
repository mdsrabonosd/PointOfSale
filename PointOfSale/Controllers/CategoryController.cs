using Microsoft.AspNetCore.Mvc;
using PointOfSale.Data;
using PointOfSale.DataModel;
using PointOfSale.ViewModel;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PointOfSale.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _Dbcontext;
        public CategoryController(ApplicationDbContext dbcontext)
        {
            _Dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryCreate(CategoryVM obj)
        {
            // যদি ফিল্ড খালি থাকে বা ইনভ্যালিড হয়
            if (!ModelState.IsValid)
            {
                return View(obj); // এটি এরর মেসেজসহ পেজটি আবার লোড করবে
            }

          
            bool isDuplicate = _Dbcontext.Categories
                                         .Any(x => x.CategoryName.ToLower() == obj.CategoryName.ToLower());

            if (isDuplicate)
            {
                ModelState.AddModelError("CategoryName", "This name is already exist");
                return View(obj);
            }

            var data = new Category
            {
                CategoryName = obj.CategoryName.Trim(),
                IsActive = obj.IsActive
            };

            _Dbcontext.Categories.Add(data);
            _Dbcontext.SaveChanges();

            return RedirectToAction("CategoryList");
        }
        public IActionResult CategoryList()
        {
            var datalist = _Dbcontext.Categories.Select(x => new CategoryVM

            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                IsActive = x.IsActive
            })
                .ToList();

            return View(datalist);
        }
        //public IActionResult CatagoryList()
        //{
        //    var datalist = _Dbcontext.Catagories.ToList();
        //    return View(datalist);
        //}
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _Dbcontext.Categories.FirstOrDefault(x => x.CategoryId == id);

            if (data == null)
            {
                return NotFound();
            }

            var vm = new CategoryVM
            {
                CategoryId = data.CategoryId,
                CategoryName = data.CategoryName,
                IsActive = data.IsActive
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(CategoryVM obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }

            var data = _Dbcontext.Categories.FirstOrDefault(x => x.CategoryId == obj.CategoryId);

            if (data == null)
            {
                return NotFound();
            }

            data.CategoryName = obj.CategoryName;
            data.IsActive = obj.IsActive;

            _Dbcontext.SaveChanges();

            return RedirectToAction("CategoryList");
        }

        //public IActionResult Delete(int ID)
        //{
        //    var data = _Dbcontext.Catagories.FirstOrDefault(x => x.CatagoryId == ID);
        //    _Dbcontext.Catagories.Remove(data);
        //    _Dbcontext.SaveChanges();
        //    return RedirectToAction("CatagoryList");
        //}

        public IActionResult Delete(int ID)
        {
            if (ID == 0)
            {
                return Json("not valid");
            }

            var chackdata = _Dbcontext.Categories.Where(x => x.CategoryId == ID).FirstOrDefault();

            if (chackdata != null)
            {
                _Dbcontext.Remove(chackdata);
                _Dbcontext.SaveChanges();
                return RedirectToAction("CategoryList");   
            }

            return Json("not found");

        }

        //public IActionResult Details(int id)
        //{
        //    var data = _Dbcontext.Catagories.FirstOrDefault(x => x.CatagoryId == id);
        //    return View(data);
        //}
        public IActionResult Details(int id)
        {
            var data = _Dbcontext.Categories
                                 .FirstOrDefault(x => x.CategoryId == id);

            if (data == null)
            {
                return NotFound();
            }

            CategoryVM vm = new CategoryVM()
            {
                CategoryId = data.CategoryId,
                CategoryName = data.CategoryName,
                IsActive = data.IsActive
            };

            return View(vm);
        }
       




    }
}
