//using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Web;
using AutoMapper;
using Vehicle.Service;
using Vehicle.MVC.Models;  
//using Vehicle.MVC.AutomapperProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace Vehicle.MVC.AutomapperConfiguration
    
{
   
    public static class MappingProfile 
    {
        
        public static void InitializeAutomapper()//poziva se u global.asax.cs--->inicijalizacija Mappera
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<VehicleMake, VehicleMakeModelView>(); });//inicijalizacija i kreiranje 


        }
        
      


    }


}