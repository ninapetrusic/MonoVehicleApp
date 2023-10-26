using Model.Common;
using Repository.Common;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        IVehicleMakeRepository vehicleMakeRepository;

        public VehicleMakeService(IVehicleMakeRepository vehicleMakeRepository)
        {
            this.vehicleMakeRepository = vehicleMakeRepository;
        }

        public async Task<bool> DeleteVehicleMakeAsync(int id)
        {
            return await vehicleMakeRepository.DeleteVehicleMakeAsync(id);
        }

        public Task<IVehicleMake> GetVehicleMakeByIdAsync(int id)
        {
            return await vehicleMakeRepository.GetVehicleMakeByIdAsync(id);
        }

        public async Task<List<IVehicleMake>> GetVehicleMakesAsync()
        {
            return await vehicleMakeRepository.GetVehicleMakesAsync();
        }

        public async Task<string> InsertVehicleMakeAsync(IVehicleMake vehicleMake)
        {
            return await vehicleMakeRepository.InsertVehicleMakeAsync(vehicleMake);
        }

        public async Task<string> UpdateVehicleMakeAsync(int id, IVehicleMake vehicleMake)
        {
            return await vehicleMakeRepository.UpdateVehicleMakeAsync(id, vehicleMake);
        }
    }
}
