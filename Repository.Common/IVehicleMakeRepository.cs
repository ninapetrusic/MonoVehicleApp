using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IVehicleMakeRepository : IDisposable
    {
        IEnumerable<VehicleMake> GetVehicleMakes();
        VehicleMake GetVehicleMakeById(int id);
        void InsertVehicleMake(VehicleMake vehicleMake);
        void DeleteVehicleMake(int id);
        void UpdateVehicleMake(VehicleMake vehicleMake);
        void Save();
    }
}
