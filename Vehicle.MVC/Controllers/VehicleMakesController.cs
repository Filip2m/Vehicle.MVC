using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vehicle.Service;
using PagedList;

namespace Vehicle.MVC.Controllers
{
    public class VehicleMakesController : Controller
    {
        private VehicleContext db = new VehicleContext();

        // GET: VehicleMakes
        public ActionResult Index(string sortOrder, string searchString, int? page, string currentFilter)
        {
            ViewBag.currentSort = sortOrder;

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";//ako je sortOrder prazan ili null, default se postavlja sortiranje padajuce poimenu

            ViewBag.AbrvSortParm = sortOrder == "Abrv" ? "Abrv_desc" : "Abrv"; //ako je sortOrder Abrv ispunjava se prvi uvijet, ako sortOrder nije Abrv, ispunjava sedrugi uvijet

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;//ovaj viewBag sluzi da se pritiskom na ime (actionLink) koji sortira zapamti sto se trazilo

            var Makes1 = from s in db.Makes //'povlaci' marke iz baze
                           select s;

            if (!string.IsNullOrEmpty(searchString))//ako string nije prazan ili null, trazi
            {
                Makes1 = Makes1.Where(s => s.Name.Contains(searchString)||s.Abrv.Contains(searchString));//trazenje po imenu i kratici marke
            }

            switch (sortOrder)
            {
                case "name_desc":
                    Makes1 = Makes1.OrderByDescending(s => s.Name);
                    break;
                case "Abrv":
                    Makes1 = Makes1.OrderBy(s => s.Abrv);
                    break;
                case "Abrv_desc":
                    Makes1 = Makes1.OrderByDescending(s => s.Abrv);
                    break;
                default:
                    Makes1 = Makes1.OrderBy(s => s.Name);
                    break;
            }


            int pageNumber = (page?? 1);//ako je page null tada je pageNumber=1
            int pageSize = 5;
            return View(Makes1.ToPagedList(pageNumber, pageSize));
        }

        // GET: VehicleMakes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMake vehicleMake = db.Makes.Find(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // GET: VehicleMakes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleMakes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,abrv")] VehicleMake vehicleMake)
        
        {
            if (ModelState.IsValid)
            {
                db.Makes.Add(vehicleMake);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicleMake);
        }

        // GET: VehicleMakes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMake vehicleMake = db.Makes.Find(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // POST: VehicleMakes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,abrv")] VehicleMake vehicleMake)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleMake).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicleMake);
        }

        // GET: VehicleMakes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMake vehicleMake = db.Makes.Find(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // POST: VehicleMakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleMake vehicleMake = db.Makes.Find(id);
            db.Makes.Remove(vehicleMake);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
