using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        protected VehicleContext _context;
        public UnitOfWork(VehicleContext context)
        {
            _context = context;
        }

        public virtual Task<int> AddAsync<T>(T entity) where T : class
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

        public virtual async Task<int> CommitAsync()
        {
            int result = 0;
            using(TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                result = await _context.SaveChangesAsync();
                scope.Complete();
            }
            return result;
        }

        public virtual Task<int> DeleteAsync<T>(T entity) where T : class
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

        public virtual Task<int> DeleteAsync<T>(int id) where T : class
        {
            var entity = _context.Set<T>().Find(id);
            return (entity == null) ? Task.FromResult(0) : DeleteAsync<T>(entity);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public virtual Task<int> UpdateAsync<T>(T entity) where T : class
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
