using AutoMapper;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model.Common;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private readonly IMapper _mapper;
        private VehicleContext _context;

        public VehicleModelRepository(IMapper mapper, VehicleContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task DeleteVehicleModelAsync(int id)
        {
            IVehicleModel? vehicleModel = await _getVehicleModelById(id);
            //map Model.VehicleModel to DAL.VehicleModel
            VehicleModel vehicleModelMapped = _mapper.Map<VehicleModel>(vehicleModel);
            _context.Models.Remove(vehicleModelMapped);
            await _context.SaveChangesAsync().ConfigureAwait(true);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<IVehicleModel> GetVehicleModelByIdAsync(int id)
        {
            return await _getVehicleModelById(id).ConfigureAwait(true);
        }

        public async Task<IEnumerable<IVehicleModel>> GetVehicleModelsAsync()
        {
            return await _mapper.Map<DbSet<IVehicleModel>>(_context.Models)
                .ToListAsync().ConfigureAwait(true);
        }

        public async Task InsertVehicleModelAsync(IVehicleModel vehicleModel)
        {
            //TODO: validation

            _context.Models.Add(_mapper.Map<VehicleModel>(vehicleModel)); ;
            await _context.SaveChangesAsync().ConfigureAwait(true);
        }

        public async Task UpdateVehicleModelAsync(int id, IVehicleModel vehicleModel)
        {
            IVehicleModel? vehicleModelOld = await _getVehicleModelById(id).ConfigureAwait(true);
            //TODO: validation
           
            _mapper.Map(vehicleModel, vehicleModelOld);
            _context.Models.Update(_mapper.Map<VehicleModel>(vehicleModelOld));
            await _context.SaveChangesAsync();
        }

        private async Task<IVehicleModel> _getVehicleModelById(int id)
        {
            VehicleModel? vehicleModel = await _context.Models
                .AsNoTracking().Where(x => x.Id == id)
                .FirstOrDefaultAsync().ConfigureAwait(true);
            //map DAL.VehicleModel to Model.VehicleModel
            IVehicleModel vehicleModelMapped = _mapper.Map<IVehicleModel>(vehicleModel);
            if (vehicleModelMapped == null)
                throw new KeyNotFoundException("VehicleModel not found");
            return vehicleModelMapped;
        }
    }
}
