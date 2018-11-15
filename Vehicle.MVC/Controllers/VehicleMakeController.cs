﻿using System;
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
using Vehicle.MVC.AutomapperConfiguration;


namespace Vehicle.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        
       // private IMapper _mapper { get; set; }

       

        public VehicleMakeController() { }
        //public VehicleMakeController(IMapper mapper)
        //{
        //    _mapper = mapper;


        //}

        
        IVehicleMakeService service = new VehicleMakeService();

       
        public ActionResult Index(/*string searchWord,*/ string sortOrder = "name_desc", int pageNumber=1, int pageSize=5 )
        {
            var cfg = new MappingProfile().InitializeAutoMapper();
            var iMapper = cfg.CreateMapper();
            var proba = service.Filter(pageNumber, pageSize, /*searchWord,*/ sortOrder).ToPagedList(1,5);

            var makes = iMapper.Map<IEnumerable<VehicleMake>, IEnumerable<VehicleMakeModelView>>(proba);
           //var makes = _mapper.Map<IEnumerable<VehicleMakeModelView>>(proba);
            
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
                service.CreateVehicleMake(Mapper.Map<VehicleMake>(make));
                return RedirectToAction("Index");
            }
            return View();
           
        }

        public ActionResult Details(int id)
        {
            var cfg = new MappingProfile().InitializeAutoMapper();
            var iMapper = cfg.CreateMapper();
            if (id == null)//provjerava je li predan id, ako nije => bad request
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMake make = service.GetById(id);
            if (make==null)//ako nije pronadena marka pod predanim id-em vraca not found
            {
                return HttpNotFound();
            }

            return View(iMapper.Map<VehicleMakeModelView>(make));//_mapper changed to iMapper=>if not working
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