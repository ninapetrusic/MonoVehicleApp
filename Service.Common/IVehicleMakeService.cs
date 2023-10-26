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
        Task<List<IVehicleMake>> GetVehicleMakesAsync();
        Task<IVehicleMake> GetVehicleMakeByIdAsync(int id);
        Task<string> InsertVehicleMakeAsync(IVehicleMake vehicleMake);
        Task<string> UpdateVehicleMakeAsync(int id, IVehicleMake vehicleMake);
        Task<bool> DeleteVehicleMakeAsync(int id);
    }
}
