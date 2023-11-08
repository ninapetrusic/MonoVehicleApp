using AutoMapper;
using DAL;
using Model.Common;
using Repository;
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
                    await _unitOfWork.vehicleMakeRepo.Delete(data).ConfigureAwait(true);
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

        public async Task<IEnumerable<IVehicleMake>> GetVehicleMakesAsync()
        {
            IEnumerable<DAL.VehicleMake> data = await _unitOfWork.vehicleMakeRepo.GetAllAsync().ConfigureAwait(true);
            return _mapper.Map<IEnumerable<DAL.VehicleMake>, IEnumerable<IVehicleMake>>(data);
        }

        public async Task<bool> InsertVehicleMakeAsync(IVehicleMake vehicleMake)
        {
            if (vehicleMake != null)
            {
                DAL.VehicleMake vehicleMakeMapped = _mapper.Map<IVehicleMake, DAL.VehicleMake>(vehicleMake);
                await _unitOfWork.vehicleMakeRepo.Insert(vehicleMakeMapped);
                int result = await _unitOfWork.CommitAsync().ConfigureAwait(true);
                return result > 0;
            }
            return false;
        }

        public async Task<bool> UpdateVehicleMakeAsync(int id, IVehicleMake vehicleMake)
        {
            if (vehicleMake != null)
            {
                DAL.VehicleMake vehicleMakeToUpdate = await _unitOfWork.vehicleMakeRepo.GetByIdAsync(id).ConfigureAwait(true);
                if (vehicleMakeToUpdate != null)
                {
                    DAL.VehicleMake vehicleMakeMapped = _mapper.Map<IVehicleMake, DAL.VehicleMake>(vehicleMake);
                    await _unitOfWork.vehicleMakeRepo.Update(vehicleMakeMapped);
                    int result = await _unitOfWork.CommitAsync().ConfigureAwait(true);
                    return result > 0;
                }
            }
            return false;
        }
    }
}
