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
        IEnumerable<IVehicleMake> GetVehicleMakesAsync();
        IVehicleMake GetVehicleMakeByIdAsync(int id);
        void InsertVehicleMakeAsync(IVehicleMake vehicleMake);
        void DeleteVehicleMakeAsync(int id);
        void UpdateVehicleMakeAsync(IVehicleMake vehicleMake);
        void Save();
    }
}
