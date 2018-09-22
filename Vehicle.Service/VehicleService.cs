using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Service
{
    public class VehicleService : IVehicleService
    {
        VehicleContext db = new VehicleContext();
        public VehicleMake GetById(Guid id)
        {
            
            var make=db.Makes.Find(id);
            return make;
        }

        public void Create(VehicleMake make)
        {
            db.Makes.Add(make);
            db.SaveChanges();
        }
    }
}
