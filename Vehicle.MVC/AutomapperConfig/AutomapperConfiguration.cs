//using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Web;
using AutoMapper;
using Vehicle.Service;
using Vehicle.MVC.Models;  
using Vehicle.MVC.AutomapperProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace Vehicle.MVC.AutomapperConfiguration
    
{
   
    public  class MappingProfile 
    {
        //public static MapperConfiguration InitializeAutoMapper()
        //{
        //    MapperConfiguration config = new MapperConfiguration(cfg =>
        //    {

        //        cfg.AddProfile(new VehicleProfile());

        //    });
        //    IServiceCollection services = new ServiceCollection();
        //    //IMapper mapper = config.CreateMapper();
        //    var mapper = new Mapper(config);
        //    services.AddSingleton(mapper);
        //    return config;

        //}
        public  MapperConfiguration InitializeAutoMapper()

        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {

                cfg.AddProfile(new VehicleProfile());

            });
            
            //IServiceCollection services = new ServiceCollection();
            //IMapper mapper = config.CreateMapper();
            var mapper = new Mapper(config);
            //services.AddSingleton(mapper);
            return config;

        }


    }


}