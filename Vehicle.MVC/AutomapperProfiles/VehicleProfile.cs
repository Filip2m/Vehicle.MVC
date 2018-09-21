using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vehicle.Service;
using Vehicle.MVC.Models;

namespace Vehicle.MVC.AutomapperProfiles
{
    public class VehicleProfile : AutoMapper.Profile
    {
        public VehicleProfile()
        {
            CreateMap<VehicleMake, VehicleMakeModelView>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelModelView>().ReverseMap();
        }

    }
}