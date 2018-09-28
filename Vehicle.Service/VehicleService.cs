using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
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
        public void Edit(VehicleMake make)
        {
            db.Entry(make).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(Guid id)
        {
            var make = db.Makes.Find(id);
            db.Makes.Remove(make);
            db.SaveChanges();
        }
        public IEnumerable<VehicleMake> GetAllMakes()
        {
            var make= from s in db.Makes select s;
            IEnumerable<VehicleMake> makes = make.ToList();
            return makes;
            
        }

        
        public IEnumerable<VehicleMake> Filter(int pageNumber, int pageSize, string searchWord, string sortOrder)
        {

            var makes = from m in db.Makes select m;

            if(!string.IsNullOrEmpty(searchWord))
            {
                makes = makes.Where(m => m.Name.Contains(searchWord) || m.Abrv.Contains(searchWord));
            }

            switch(sortOrder)
            {
                case "name_desc":
                    makes = makes.OrderByDescending(m => m.Name);
                    break;
                default:
                    makes = makes.OrderBy(m => m.Name);
                    break;
            }
            IEnumerable<VehicleMake> makesList = makes;
            return makesList;
        }
        //public IEnumerable<VehicleMake> Search(string searchWord)
        //{
        //    var makes = from s in db.Makes select s;
        //    if (!string.IsNullOrEmpty(searchWord))
        //    {
        //        makes = makes.Where(m => m.Name.Contains(searchWord) || m.Abrv.Contains(searchWord));
        //    }
        //    IEnumerable<VehicleMake> makesList = makes.ToList();
        //    return makesList;
        //}
    }
}
