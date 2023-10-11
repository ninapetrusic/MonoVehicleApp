using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IVehicleModelRepository : IDisposable
    {
        IEnumerable<VehicleModel> GetVehicleModels();
        VehicleModel GetVehicleModelById(int id);
        void InsertVehicleModel(VehicleModel vehicleModel);
        void DeleteVehicleModel(int id);
        void UpdateVehicleModel(VehicleModel vehicleModel);
        void Save();
    }
}
