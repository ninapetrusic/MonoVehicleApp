using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        protected VehicleContext vehicleContext;
        public UnitOfWork(VehicleContext vehicleContext)
        {
            if (vehicleContext == null)
                throw new ArgumentNullException("VehicleContext")
            this.vehicleContext = vehicleContext;
        }

        public Task<int> AddAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<int> CommitAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync<T>(string ID) where T : class
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
