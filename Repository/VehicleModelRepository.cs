using AutoMapper;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
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
            DAL.VehicleModel vehicleModelMapped = _mapper.Map<DAL.VehicleModel>(vehicleModel);
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

        public async Task<int> InsertVehicleModelAsync(IVehicleModel vehicleModel)
        {
            //TODO: validation
            DAL.VehicleModel model = _mapper.Map<DAL.VehicleModel>(vehicleModel);
            _context.Models.Add(model); ;
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return model.Id;
        }

        public async Task UpdateVehicleModelAsync(int id, IVehicleModel vehicleModel)
        {
            IVehicleModel? vehicleModelOld = await _getVehicleModelById(id).ConfigureAwait(true);
            //TODO: validation
           
            _mapper.Map(vehicleModel, vehicleModelOld);
            _context.Models.Update(_mapper.Map<DAL.VehicleModel>(vehicleModelOld));
            await _context.SaveChangesAsync();
        }

        private async Task<IVehicleModel> _getVehicleModelById(int id)
        {
            DAL.VehicleModel? vehicleModel = await _context.Models
                .AsNoTracking().Where(x => x.Id == id)
                .FirstOrDefaultAsync().ConfigureAwait(true);
            //map DAL.VehicleModel to Model.VehicleModel
            IVehicleModel vehicleModelMapped = _mapper.Map<Model.VehicleModel>(vehicleModel);
            if (vehicleModelMapped == null)
                throw new KeyNotFoundException("VehicleModel not found");
            return vehicleModelMapped;
        }
    }
}
