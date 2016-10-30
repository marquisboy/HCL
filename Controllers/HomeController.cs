using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HCLProj.Repo;
using HCLProj.Models;
using PagedList;
using System.Net;

namespace HCLProj.Controllers
{
    public class HomeController : Controller
    {
        //private HCL2Entities context = new HCL2Entities();
        private IHCLRepo repository = new HCLRepo();
        private HCL2Entities context = new HCL2Entities();
        private int pageSize = 8;

        public int PageSize { get; set; }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Product
        public HomeController( )
        {
            
        }

        [HttpGet]
        public ActionResult Add ( )
        {
            Car car = new Car();

            return View(car);
        }

        public ActionResult Add(Car car)
        {
            if ( ModelState.IsValid )
            {
                repository.SaveCar(car);
            }

            return RedirectToAction("List");
        }

        public ViewResult List( string field ="", string val="",  int page = 1)
        {
            List<Car> cars = new List<Car>();
            ViewBag.field = field;
            ViewBag.val = val;
            switch(field)
            {
                case "Make":
                    cars = context.Cars.Where(c => c.make.Contains(val)).ToList();
                    break;
                case "Model":
                    cars = context.Cars.Where(c => c.model_name.Contains(val)).ToList();
                    break;
                default:
                    if (val == "")
                        cars = context.Cars.ToList();
                    break;
            }
           // List<Car> cars = repository.Cars.Where(c=>c.model_name == model || model=="").ToList();

            PagedList<Car> pagedCars = new PagedList<Car>(cars,page,pageSize);

            return View(pagedCars);
        }

        public ActionResult Find(int id)
        {
            //ViewBag.field = field;
            //ViewBag.val = val;
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = repository.GetCar(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View("Edit", car);
        }

        public ActionResult Edit(int id, string field="", string val="" )
        {
            ViewBag.field = field;
            ViewBag.val = val;
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = repository.GetCar(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Car car, string field = "", string val = "")
        {
            ViewBag.field = field;
            ViewBag.val = val;
            if (ModelState.IsValid)
            {

                repository.SaveCar(car);

                return RedirectToAction("List", new { field = field, val = val });
            }
            return View(car);
        }

        public ActionResult Delete(int? id, string field="", string val="" )
        {
            ViewBag.field = field;
            ViewBag.val = val;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = context.Cars.FirstOrDefault(c => c.id == id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string field = "", string val = "")
        {
            ViewBag.field = field;
            ViewBag.val = val;
            Car car = context.Cars.Find(id);
            context.Cars.Remove(car);
            context.SaveChanges();
            return RedirectToAction("List", new { field = field, val = val });
        }

    }
}            
