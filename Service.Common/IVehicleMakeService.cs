﻿using Common;
using Model;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Common
{
    public interface IVehicleMakeService
    {
        Task<IEnumerable<IVehicleMake>> GetVehicleMakesAsync(QueryParams queryParams);
        Task<IVehicleMake> GetVehicleMakeByIdAsync(int id);
        Task<bool> InsertVehicleMakeAsync(VehicleMakeCreate vehicleMake);
        Task<bool> UpdateVehicleMakeAsync(int id, VehicleMakeCreate vehicleMake);
        Task<bool> DeleteVehicleMakeAsync(int id);
    }
}
