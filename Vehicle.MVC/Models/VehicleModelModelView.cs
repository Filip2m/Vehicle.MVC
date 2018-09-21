using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vehicle.MVC.Models
{
    public class VehicleModelModelView
    {
      
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public virtual VehicleMakeModelView MakeModelView { get; set; }
    }
}