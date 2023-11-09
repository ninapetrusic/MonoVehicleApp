using Common;
using Model;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Common
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<IVehicleModel>> GetVehicleModelsAsync(QueryParams queryParams);
        Task<IVehicleModel> GetVehicleModelByIdAsync(int id);
        Task<bool> InsertVehicleModelAsync(VehicleModelCreate vehicleModel);
        Task<bool> UpdateVehicleModelAsync(int id, VehicleModelCreate vehicleModel);
        Task<bool> DeleteVehicleModelAsync(int id);
    }
}
