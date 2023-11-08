using DAL;
using Microsoft.EntityFrameworkCore;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        protected VehicleContext _context;
        public IGenericRepository<VehicleMake> vehicleMakeRepo { get; }
        public IGenericRepository<VehicleModel> vehicleModelRepo { get; }

        public UnitOfWork(VehicleContext context, IGenericRepository<VehicleMake> vehicleMakeRepo, IGenericRepository<VehicleModel> vehicleModelRepo)
        {
            _context = context;
            this.vehicleMakeRepo = vehicleMakeRepo;
            this.vehicleModelRepo = vehicleModelRepo;
        }

        public Task<int> AddAsync<T>(T entity) where T : class
        {
            var dbEntityEntry = _context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                _context.Set<T>().Add(entity);
            }
            return Task.FromResult(1);
        }

        public async Task<int> CommitAsync()
        {
            int result = 0;
            using(TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                result = await _context.SaveChangesAsync();
                scope.Complete();
            }
            return result;
        }

        public Task<int> DeleteAsync<T>(T entity) where T : class
        {
            var entityEntry = _context.Entry(entity);
            if (entityEntry.State != EntityState.Deleted)
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                _context.Set<T>().Attach(entity);
                _context.Set<T>().Remove(entity);
            }
            return Task.FromResult(1);
        }

        public Task<int> DeleteAsync<T>(int id) where T : class
        {
            var entity = _context.Set<T>().Find(id);
            return (entity == null) ? Task.FromResult(0) : DeleteAsync<T>(entity);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<int> UpdateAsync<T>(T entity) where T : class
        {
            var entityEntry = _context.Entry(entity);
            if (entityEntry.State != EntityState.Detached)
            {
                _context.Set<T>().Attach(entity);
            }
            entityEntry.State = EntityState.Modified;
            return Task.FromResult(1);
        }
    }
}
