using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Service
{
   public interface IVehicleService
    {
        void Create(VehicleMake t);
        void Read(VehicleMake t);
        void Update(VehicleMake t);
        void Delete(VehicleMake t);
    }
}
