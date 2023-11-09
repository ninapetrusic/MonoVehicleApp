using AutoMapper;
using Common;
using Model;
using Model.Common;
using Repository.Common;
using Service.Common;

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
                    await _unitOfWork.DeleteAsync(data).ConfigureAwait(true);
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

        public async Task<IEnumerable<IVehicleModel>> GetVehicleModelsAsync(QueryParams queryParams)
        {
            IEnumerable<DAL.VehicleModel> data = await _unitOfWork.vehicleModelRepo.GetAllAsync(queryParams).ConfigureAwait(true);
            return _mapper.Map<IEnumerable<DAL.VehicleModel>, IEnumerable<IVehicleModel>>(data);
        }

        public async Task<bool> InsertVehicleModelAsync(VehicleModelCreate vehicleModel)
        {
            if (vehicleModel != null)
            {
                DAL.VehicleModel vehicleModelMapped = _mapper.Map<VehicleModelCreate, DAL.VehicleModel>(vehicleModel);
                int addRes = await _unitOfWork.AddAsync(vehicleModelMapped);
                if (addRes > 0)
                {
                    int result = await _unitOfWork.CommitAsync().ConfigureAwait(true);
                    return result > 0;
                }
            }
            return false;
        }

        public async Task<bool> UpdateVehicleModelAsync(int id, VehicleModelCreate vehicleModel)
        {
            if (vehicleModel != null)
            {
                DAL.VehicleModel vehicleModelToUpdate = await _unitOfWork.vehicleModelRepo.GetByIdAsync(id).ConfigureAwait(true);
                if (vehicleModelToUpdate != null)
                {
                    DAL.VehicleModel vehicleModelMapped = _mapper.Map<VehicleModelCreate, DAL.VehicleModel>(vehicleModel);
                    _mapper.Map(vehicleModelMapped, vehicleModelToUpdate);
                    int updateRes = await _unitOfWork.UpdateAsync(vehicleModelMapped).ConfigureAwait(true);
                    if (updateRes > 0)
                    {
                        int result = await _unitOfWork.CommitAsync().ConfigureAwait(true);
                        return result > 0;
                    }
                }
            }
            return false;
        }
    }
}
