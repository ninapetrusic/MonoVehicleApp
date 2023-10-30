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
        private VehicleContext _context;
        public async Task DeleteVehicleMakeAsync(int id)
        {
            IVehicleMake? vehicleMake = await _getVehicleMakeById(id);
            _context.VehicleMakes.Remove(vehicleMake);
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
            return await _context.VehicleMakes.
                ToListAsync().ConfigureAwait(true);

        }

        public async Task InsertVehicleMakeAsync(IVehicleMake vehicleMake)
        {
            //TODO: validation
            //TODO: auto mapper
            /*
            IVehicleMake vehicleMakeNew = _mapper.Map<VehicleMake>(vehicleMake);
            _context.VehicleMakes.Add(vehicleMakeNew);
            */
            await _context.SaveChangesAsync().ConfigureAwait(true);
        }
        public async Task UpdateVehicleMakeAsync(int id, IVehicleMake vehicleMake)
        {
            IVehicleMake? vehicleMakeOld = await _getVehicleMakeById(id).ConfigureAwait(true);
            // TODO: validation
            // TODO: auto mapper
            /*
            _mapper.Map(vehicleMake, vehicleMakeOld);
            _context.VehicleMakes.Update(vehicleMakeOld);
            */
            await _context.SaveChangesAsync();
        }

        private async Task<IVehicleMake> _getVehicleMakeById(int id)
        {
            IVehicleMake? vehicleMake = await _context.VehicleMakes
                .AsNoTracking().Where(x => x.Id == id)
                .FirstOrDefaultAsync().ConfigureAwait(true);
            if (vehicleMake == null)
                throw new KeyNotFoundException("VehicleMake not found");
            return vehicleMake;
        }
    }
}
