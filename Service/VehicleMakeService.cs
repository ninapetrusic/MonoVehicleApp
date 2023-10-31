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
        private IVehicleMakeRepository vehicleMakeRepository;

        public VehicleMakeService(IVehicleMakeRepository vehicleMakeRepository)
        {
            this.vehicleMakeRepository = vehicleMakeRepository;
        }

        public async Task DeleteVehicleMakeAsync(int id)
        {
            await vehicleMakeRepository.DeleteVehicleMakeAsync(id);
        }

        public async Task<IVehicleMake> GetVehicleMakeByIdAsync(int id)
        {
            return await vehicleMakeRepository.GetVehicleMakeByIdAsync(id);
        }

        public async Task<IEnumerable<IVehicleMake>> GetVehicleMakesAsync()
        {
            return await vehicleMakeRepository.GetVehicleMakesAsync();
        }

        public async Task InsertVehicleMakeAsync(IVehicleMake vehicleMake)
        {
            await vehicleMakeRepository.InsertVehicleMakeAsync(vehicleMake);
        }

        public async Task UpdateVehicleMakeAsync(int id, IVehicleMake vehicleMake)
        {
            await vehicleMakeRepository.UpdateVehicleMakeAsync(id, vehicleMake);
        }
    }
}
