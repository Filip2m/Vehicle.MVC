using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Service
{
   public interface IVehicleService
    {
        VehicleMake GetById(int id);
        void Create(VehicleMake make);
        void Edit(VehicleMake make);
        void Delete(int id);
        //IEnumerable<VehicleMake> Search(string searchWord);
        IEnumerable<VehicleMake> GetAllMakes();
        IEnumerable<VehicleMake> Filter(int pageNumber, int pageSize, string searchWord, string sortOrder);
    }
}
