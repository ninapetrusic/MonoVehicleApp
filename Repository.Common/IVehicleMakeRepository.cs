using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IVehicleMakeRepository : IDisposable
    {
        Task<IEnumerable<IVehicleMake>> GetVehicleMakesAsync();
        Task<IVehicleMake> GetVehicleMakeByIdAsync(int id);
        Task InsertVehicleMakeAsync(IVehicleMake vehicleMake);
        Task DeleteVehicleMakeAsync(int id);
        Task UpdateVehicleMakeAsync(int id, IVehicleMake vehicleMake);
    }
}
