using AutoMapper;
using DAL;
using Microsoft.EntityFrameworkCore;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly VehicleContext _context;
        public readonly DbSet<T> dbSet;

        protected readonly IMapper _mapper;

        public GenericRepository(VehicleContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            dbSet = _context.Set<T>();
        }

        public Task Delete(T entity)
        {
            dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync().ConfigureAwait(true);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id).ConfigureAwait(true);
        }

        public async Task<T> Insert(T entity)
        {
            await dbSet.AddAsync(entity).ConfigureAwait(true);
            return entity;
        }

        public async Task Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
