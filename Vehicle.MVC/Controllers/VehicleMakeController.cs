using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vehicle.MVC.Models;
using Vehicle.Service;
using AutoMapper;
using PagedList;
using Microsoft.Extensions.DependencyInjection;




namespace Vehicle.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {

        

       

        public VehicleMakeController() { }
      
       

        IVehicleMakeService service = new VehicleMakeService();

       
        public ActionResult Index(/*string searchWord,*/ string sortOrder = "name_desc", int pageNumber=1, int pageSize=5 )
        {
            
            var proba = service.Filter(pageNumber, pageSize, /*searchWord,*/ sortOrder).ToPagedList(1,5);

            var makes = Mapper.Map<IEnumerable<VehicleMake>, IEnumerable<VehicleMakeModelView>>(proba);
           
            
            


            return View(makes);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include ="Id, Name, Abrv")] VehicleMakeModelView make)
        {
            //make.Id = Guid.NewGuid();
            
            if(ModelState.IsValid)
            {
                service.CreateVehicleMake(Mapper.Map<VehicleMake>(make));
                return RedirectToAction("Index");
            }
            return View();
           
        }

        public ActionResult Details(int id)
        {
           
            if (id == null)//provjerava je li predan id, ako nije => bad request
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMake make = service.GetById(id);
            if (make==null)//ako nije pronadena marka pod predanim id-em vraca not found
            {
                return HttpNotFound();
            }

            return View(Mapper.Map<VehicleMakeModelView>(make));
        }
        public ActionResult Delete(int id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            service.Delete(id);
            return RedirectToAction("index");
        }
    }
}