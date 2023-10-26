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
        IVehicleModelRepository vehicleModelRepository;
        public VehicleModelService(IVehicleModelRepository vehicleModelRepository)
        {
            this.vehicleModelRepository = vehicleModelRepository;
        }
        public async Task<bool> DeleteVehicleModelAsync(int id)
        {
            return await vehicleModelRepository.DeleteVehicleModelAsync(id);
        }

        public async Task<IVehicleModel> GetVehicleModelByIdAsync(int id)
        {
            return await vehicleModelRepository.GetVehicleModelByIdAsync(id);
        }

        public async Task<List<IVehicleModel>> GetVehicleModelsAsync()
        {
            return await vehicleModelRepository.GetVehicleModelsAsync();
        }

        public async Task<string> InsertVehicleModelAsync(IVehicleModel vehicleModel)
        {
            return await vehicleModelRepository.InsertVehicleModelAsync(vehicleModel);
        }

        public async Task<string> UpdateVehicleModelAsync(int id, IVehicleModel vehicleModel)
        {
            return await vehicleModelRepository.UpdateVehicleModelAsync(id, vehicleModel);
        }
    }
}
