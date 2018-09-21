using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vehicle.MVC.Models
{
    public class VehicleMakeModelView
    {
        public VehicleMakeModelView()
        {

        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public ICollection<VehicleModelModelView> VehicleMakeModelViewObj { get; set; }
    }
}