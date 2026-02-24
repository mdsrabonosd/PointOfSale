using Microsoft.AspNetCore.Mvc;
using PointOfSale.Data;
using PointOfSale.DataModel;
using PointOfSale.ViewModel;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            if (!ModelState.IsValid)
            {
                return View(obj);
            }
            var data = new Catagory
            {
                CatagoryName = obj.CatagoryName,
                IsActive = obj.IsActive
            };

            _Dbcontext.Catagories.Add(data);
            _Dbcontext.SaveChanges();

            return RedirectToAction("CatagoryList");
        }

       
       
        public IActionResult CatagoryList()
        {
            var datalist = _Dbcontext.Catagories.Select(x => new CatagoryVM

            {
                CatagoryId = x.CatagoryId,
                CatagoryName = x.CatagoryName,
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
            var data = _Dbcontext.Catagories.FirstOrDefault(x => x.CatagoryId == id);

            if (data == null)
            {
                return NotFound();
            }

            var vm = new CatagoryVM
            {
                CatagoryId = data.CatagoryId,
                CatagoryName = data.CatagoryName,
                IsActive = data.IsActive
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(CatagoryVM obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }

            var data = _Dbcontext.Catagories.FirstOrDefault(x => x.CatagoryId == obj.CatagoryId);

            if (data == null)
            {
                return NotFound();
            }
            data.CatagoryName = obj.CatagoryName;
            data.IsActive = obj.IsActive;

            _Dbcontext.SaveChanges();

            return RedirectToAction("CatagoryList");
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

            var chackdata = _Dbcontext.Catagories.Where(x => x.CatagoryId == ID).FirstOrDefault();

            if (chackdata != null)
            {
                _Dbcontext.Remove(chackdata);
                _Dbcontext.SaveChanges();
                return RedirectToAction("CatagoryList");   
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
            var data = _Dbcontext.Catagories
                                 .FirstOrDefault(x => x.CatagoryId == id);

            if (data == null)
            {
                return NotFound();
            }

            CatagoryVM vm = new CatagoryVM()
            {
                CatagoryId = data.CatagoryId,
                CatagoryName = data.CatagoryName,
                IsActive = data.IsActive
            };

            return View(vm);
        }
       

    }
}
