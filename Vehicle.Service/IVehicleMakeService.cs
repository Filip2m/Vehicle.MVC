using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Service
{
   public interface IVehicleMakeService
    {
        VehicleMake GetById(int id);
        void CreateVehicleMake(VehicleMake make);
        void Edit(VehicleMake make);
        void Delete(int id);
        //IEnumerable<VehicleMake> Search(string searchWord);
        IEnumerable<VehicleMake> Filter(int pageNumber, int pageSize,/* string searchWord,*/ string sortOrder);
    }
}
