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
    public class VehicleModelService : IVehicleModelService
    {
        private IVehicleModelRepository vehicleModelRepository;
        public VehicleModelService(IVehicleModelRepository vehicleModelRepository)
        {
            this.vehicleModelRepository = vehicleModelRepository;
        }
        public async Task DeleteVehicleModelAsync(int id)
        {
            await vehicleModelRepository.DeleteVehicleModelAsync(id);
        }

        public async Task<IVehicleModel> GetVehicleModelByIdAsync(int id)
        {
            return await vehicleModelRepository.GetVehicleModelByIdAsync(id);
        }

        public async Task<IEnumerable<IVehicleModel>> GetVehicleModelsAsync()
        {
            return await vehicleModelRepository.GetVehicleModelsAsync();
        }

        public async Task InsertVehicleModelAsync(IVehicleModel vehicleModel)
        {
            await vehicleModelRepository.InsertVehicleModelAsync(vehicleModel);
        }

        public async Task UpdateVehicleModelAsync(int id, IVehicleModel vehicleModel)
        {
            await vehicleModelRepository.UpdateVehicleModelAsync(id, vehicleModel);
        }
    }
}
