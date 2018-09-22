﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Service
{
   public interface IVehicleService
    {
        VehicleMake GetById(Guid id);
        void Create(VehicleMake make);
    }
}
