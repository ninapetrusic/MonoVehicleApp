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
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private readonly IMapper _mapper;
        private VehicleContext _context;
        public VehicleMakeRepository(IMapper mapper, VehicleContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task DeleteVehicleMakeAsync(int id)
        {
            IVehicleMake? vehicleMake = await _getVehicleMakeById(id);
            //map Model.VehicleModel to DAL.VehicleModel
            VehicleMake vehicleMakeMapped = _mapper.Map<VehicleMake>(vehicleMake);
            _context.Makes.Remove(vehicleMakeMapped);
            await _context.SaveChangesAsync().ConfigureAwait(true);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<IVehicleMake> GetVehicleMakeByIdAsync(int id)
        {
            return await _getVehicleMakeById(id).ConfigureAwait(true);
        }

        public async Task<IEnumerable<IVehicleMake>> GetVehicleMakesAsync()
        {
            return await _mapper.Map<DbSet<IVehicleMake>>(_context.Makes).
                ToListAsync().ConfigureAwait(true);

        }

        public async Task<int> InsertVehicleMakeAsync(IVehicleMake vehicleMake)
        {
            //TODO: validation
            DAL.VehicleMake make = _mapper.Map<DAL.VehicleMake>(vehicleMake);
            _context.Makes.Add(make);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return make.Id;
        }
        public async Task UpdateVehicleMakeAsync(int id, IVehicleMake vehicleMake)
        {
            IVehicleMake? vehicleMakeOld = await _getVehicleMakeById(id).ConfigureAwait(true);
            // TODO: validation

            _mapper.Map(vehicleMake, vehicleMakeOld);
            _context.Makes.Update(_mapper.Map<VehicleMake>(vehicleMakeOld));
            await _context.SaveChangesAsync();
        }

        private async Task<IVehicleMake> _getVehicleMakeById(int id)
        {
            VehicleMake? vehicleMake = await _context.Makes
                .AsNoTracking().Where(x => x.Id == id)
                .FirstOrDefaultAsync().ConfigureAwait(true);
            //map DAL.VehicleMake to Model.VehicleMake
            IVehicleMake vehicleMakeMapped = _mapper.Map<IVehicleMake>(vehicleMake);
            if (vehicleMake == null)
                throw new KeyNotFoundException("VehicleMake not found");
            return vehicleMakeMapped;
        }
    }
}
