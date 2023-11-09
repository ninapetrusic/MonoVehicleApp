using AutoMapper;
using Common;
using Model;
using Model.Common;
using Repository.Common;
using Service.Common;

namespace Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public VehicleMakeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> DeleteVehicleMakeAsync(int id)
        {
            if (id > 0)
            {
                DAL.VehicleMake data = await _unitOfWork.vehicleMakeRepo.GetByIdAsync(id).ConfigureAwait(true);
                if (data != null)
                {
                    await _unitOfWork.DeleteAsync(data).ConfigureAwait(true);
                    int result = await _unitOfWork.CommitAsync().ConfigureAwait(true);
                    return result > 0;
                }
            }
            return false;
        }

        public async Task<IVehicleMake> GetVehicleMakeByIdAsync(int id)
        {
            if (id > 0)
            {
                DAL.VehicleMake data = await _unitOfWork.vehicleMakeRepo.GetByIdAsync(id).ConfigureAwait(true);
                return _mapper.Map<DAL.VehicleMake, IVehicleMake>(data);
            }
            return null;
        }

        public async Task<IEnumerable<IVehicleMake>> GetVehicleMakesAsync(QueryParams queryParams)
        {
            IEnumerable<DAL.VehicleMake> data = await _unitOfWork.vehicleMakeRepo.GetAllAsync(queryParams).ConfigureAwait(true);
            return _mapper.Map<IEnumerable<DAL.VehicleMake>, IEnumerable<IVehicleMake>>(data);
        }

        public async Task<bool> InsertVehicleMakeAsync(VehicleMakeCreate vehicleMake)
        {
            if (vehicleMake != null)
            {
                DAL.VehicleMake vehicleMakeMapped = _mapper.Map<VehicleMakeCreate, DAL.VehicleMake>(vehicleMake);
                int addRes = await _unitOfWork.AddAsync(vehicleMakeMapped);
                if (addRes > 0)
                {
                    int result = await _unitOfWork.CommitAsync().ConfigureAwait(true);
                    return result > 0;
                }
            }
            return false;
        }

        public async Task<bool> UpdateVehicleMakeAsync(int id, VehicleMakeCreate vehicleMake)
        {
            if (vehicleMake != null)
            {
                DAL.VehicleMake vehicleMakeToUpdate = await _unitOfWork.vehicleMakeRepo.GetByIdAsync(id).ConfigureAwait(true);
                if (vehicleMakeToUpdate != null)
                {
                    DAL.VehicleMake vehicleMakeMapped = _mapper.Map<VehicleMakeCreate, DAL.VehicleMake>(vehicleMake);
                    _mapper.Map(vehicleMakeMapped, vehicleMakeToUpdate);
                    int updateRes = await _unitOfWork.UpdateAsync(vehicleMakeToUpdate);
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
