using AutoMapper;
using DAL;
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
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public VehicleModelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> DeleteVehicleModelAsync(int id)
        {
            if (id > 0)
            {
                DAL.VehicleModel data = await _unitOfWork.vehicleModelRepo.GetByIdAsync(id).ConfigureAwait(true);
                if (data != null)
                {
                    await _unitOfWork.vehicleModelRepo.Delete(data).ConfigureAwait(true);
                    int result = await _unitOfWork.CommitAsync().ConfigureAwait(true);
                    return result > 0;
                }
            }
            return false;
        }

        public async Task<IVehicleModel> GetVehicleModelByIdAsync(int id)
        {
            if (id > 0)
            {
                DAL.VehicleModel data = await _unitOfWork.vehicleModelRepo.GetByIdAsync(id).ConfigureAwait(true);
                return _mapper.Map<DAL.VehicleModel, IVehicleModel>(data);
            }
            return null;
        }

        public async Task<IEnumerable<IVehicleModel>> GetVehicleModelsAsync()
        {
            IEnumerable<DAL.VehicleModel> data = await _unitOfWork.vehicleModelRepo.GetAllAsync().ConfigureAwait(true);
            return _mapper.Map<IEnumerable<DAL.VehicleModel>, IEnumerable<IVehicleModel>>(data);
        }

        public async Task<bool> InsertVehicleModelAsync(IVehicleModel vehicleModel)
        {
            if (vehicleModel != null)
            {
                DAL.VehicleModel vehicleModelMapped = _mapper.Map<IVehicleModel, DAL.VehicleModel>(vehicleModel);
                await _unitOfWork.vehicleModelRepo.Insert(vehicleModelMapped);
                int result = await _unitOfWork.CommitAsync().ConfigureAwait(true);
                return result > 0;
            }
            return false;
        }

        public async Task<bool> UpdateVehicleModelAsync(int id, IVehicleModel vehicleModel)
        {
            if (vehicleModel != null)
            {
                DAL.VehicleModel vehicleModelToUpdate = await _unitOfWork.vehicleModelRepo.GetByIdAsync(id).ConfigureAwait(true);
                if (vehicleModelToUpdate != null)
                {
                    DAL.VehicleModel vehicleModelMapped = _mapper.Map<IVehicleModel, DAL.VehicleModel>(vehicleModel);
                    await _unitOfWork.vehicleModelRepo.Update(vehicleModelMapped);
                    int result = await _unitOfWork.CommitAsync().ConfigureAwait(true);
                    return result > 0;
                }
            }
            return false;
        }
    }
}
