using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Vehicle.MVC.AutomapperConfiguration;
using AutoMapper;
using Vehicle.Service;
using Vehicle.MVC.Models;
//using Vehicle.MVC.AutomapperProfiles;
using Microsoft.Extensions.DependencyInjection;



namespace Vehicle.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MappingProfile.InitializeAutomapper();
          



            }

    }
}
