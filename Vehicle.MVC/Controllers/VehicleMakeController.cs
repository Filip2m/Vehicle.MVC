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

namespace Vehicle.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        
        private readonly IMapper _mapper;
       
       public VehicleMakeController() { }
        public VehicleMakeController(IMapper mapper)
        {
            _mapper = mapper;
            

        }

        public IVehicleService service = new VehicleService();

        
        public ActionResult Index(string searchWord, string sortOrder, int pageNumber=1, int pageSize=5 )
        {

            var proba = service.Filter(pageNumber, pageSize, searchWord, sortOrder);
            var makes = _mapper.Map<PagedList<VehicleMakeModelView>>(proba);
            //makes.ToPagedList(pageNumber, pageSize);

            //var makesList = new StaticPagedList<VehicleMakeModelView>(makes, makes.GetMetaData());
            

            return View(makes);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include ="Id, Name, Abrv")] VehicleMakeModelView make)
        {
            //make.Id = Guid.NewGuid();
            
            if(ModelState.IsValid)
            {
                service.Create(Mapper.Map<VehicleMake>(make));
                return RedirectToAction("Index");
            }
            return View();
           
        }

        public ActionResult Details(int id)
        {
            if(id==null)//provjerava je li predan id, ako nije => bad request
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IVehicleMake make = service.GetById(id);
            if (make==null)//ako nije pronadena marka pod predanim id-em vraca not found
            {
                return HttpNotFound();
            }

            return View(_mapper.Map<VehicleMakeModelView>(make));
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