using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Service
{
    public class VehicleService : IVehicleService
    {
        
        VehicleContext makeDb = new VehicleContext();
        public void Create(VehicleMake make)
        {
             makeDb.Makes.Add(make);
        }
            
        public void Read(VehicleMake make)
        {
            var makes = new List<VehicleMake>();
            makes = makeDb.Makes.ToList();
        }

        public void Update(VehicleMake make)
        {
          
        }

        public void Delete(VehicleMake make)
        {
            makeDb.Makes.Remove(make);
        }
    }
}
