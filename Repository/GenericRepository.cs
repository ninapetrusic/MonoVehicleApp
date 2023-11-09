using AutoMapper;
using Common;
using DAL;
using Microsoft.EntityFrameworkCore;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public virtual async Task<IEnumerable<T>> GetAllAsync(QueryParams queryParams)
        {
            return await dbSet.ToListAsync().ConfigureAwait(true);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id).ConfigureAwait(true);
        }

    }
}
