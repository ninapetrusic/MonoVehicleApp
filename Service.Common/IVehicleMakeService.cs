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
        Task<IEnumerable<IVehicleMake>> GetVehicleMakesAsync();
        Task<IVehicleMake> GetVehicleMakeByIdAsync(int id);
        Task<bool> InsertVehicleMakeAsync(IVehicleMake vehicleMake);
        Task<bool> UpdateVehicleMakeAsync(int id, IVehicleMake vehicleMake);
        Task<bool> DeleteVehicleMakeAsync(int id);
    }
}
