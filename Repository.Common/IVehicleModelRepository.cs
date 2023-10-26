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
        IEnumerable<IVehicleModel> GetVehicleModelsAsync();
        IVehicleModel GetVehicleModelByIdAsync(int id);
        void InsertVehicleModelAsync(IVehicleModel vehicleModel);
        void DeleteVehicleModelAsync(int id);
        void UpdateVehicleModelAsync(IVehicleModel vehicleModel);
        void Save();
    }
}
