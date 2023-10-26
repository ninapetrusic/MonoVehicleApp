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
        Task<List<IVehicleModel>> GetVehicleModelsAsync();
        Task<IVehicleModel> GetVehicleModelByIdAsync(int id);
        Task<string> InsertVehicleModelAsync(IVehicleModel vehicleModel);
        Task<string> UpdateVehicleModelAsync(int id, IVehicleModel vehicleModel);
        Task<bool> DeleteVehicleModelAsync(int id);
    }
}
