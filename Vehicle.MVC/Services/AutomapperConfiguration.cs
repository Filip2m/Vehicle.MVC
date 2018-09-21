//using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Web;
using AutoMapper;
using Vehicle.Service;
using Vehicle.MVC.Models;  //probaj sa profilima
using Vehicle.MVC.AutomapperProfiles;


namespace Vehicle.MVC.AutomapperConfiguration
    
{
    public static class AutomapperConfiguration
    {
        public static void RegisterMaps()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new VehicleProfile());
            });
            var mapper = config.CreateMapper();
            
        }
    }
}