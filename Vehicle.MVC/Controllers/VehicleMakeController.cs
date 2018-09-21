using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vehicle.MVC.Models;
using Vehicle.Service;
using AutoMapper;
using RepositoryImplementation;

namespace Vehicle.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        
        private readonly IMapper _mapper;
       // private readonly SqlRepository<VehicleMake> _MakeRepository;

        public VehicleMakeController(/*SqlRepository<VehicleMake> MakeReposirory,*/IMapper mapper)
        {
            _mapper = mapper;
            //_MakeRepository = MakeReposirory;

        }
        public VehicleMake make = new VehicleMake();
        public IVehicleService service = new VehicleService();

        public ActionResult Index(VehicleMakeModelView makeViewModel)
        {
            //var makes = new List<VehicleMake>();
            //var makePagedList = Mapper.Map<List<VehicleMake>,List<VehicleMakeModelView>>(makes);
            //return View(makePagedList);

            
            var makes=_mapper.Map<VehicleMakeModelView>(make);
            var makesList = new List<VehicleMakeModelView>(makes);
            

            return View(makesList);
        }
        public ActionResult Create([Bind(Include ="Id, Name, Abrv")] VehicleMakeModelView make)
        {
            make.Id = new Guid();
            
            if(ModelState.IsValid)
            {
                service.Create(Mapper.Map<VehicleMake>(make));
            }

            return View();
        }
    }
}