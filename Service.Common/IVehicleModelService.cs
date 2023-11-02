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
        Task<IEnumerable<IVehicleModel>> GetVehicleModelsAsync();
        Task<IVehicleModel> GetVehicleModelByIdAsync(int id);
        Task<bool> InsertVehicleModelAsync(IVehicleModel vehicleModel);
        Task UpdateVehicleModelAsync(int id, IVehicleModel vehicleModel);
        Task DeleteVehicleModelAsync(int id);
    }
}
