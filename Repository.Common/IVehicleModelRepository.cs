using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IVehicleModelRepository : IDisposable
    {
        Task<IEnumerable<IVehicleModel>> GetVehicleModelsAsync();
        Task<IVehicleModel> GetVehicleModelByIdAsync(int id);
        Task<int> InsertVehicleModelAsync(IVehicleModel vehicleModel);
        Task DeleteVehicleModelAsync(int id);
        Task UpdateVehicleModelAsync(int id, IVehicleModel vehicleModel);
    }
}
