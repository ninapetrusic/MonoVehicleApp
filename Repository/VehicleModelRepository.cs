using AutoMapper;
using Common;
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
    public class VehicleModelRepository : GenericRepository<DAL.VehicleModel>, IVehicleModelRepository
    {
        public VehicleModelRepository(IMapper _mapper, VehicleContext context) : base(context, _mapper)
        {
        }

        public override async Task<IEnumerable<VehicleModel>> GetAllAsync(QueryParams queryParams)
        {
            if (queryParams.OrderBy == "Name")
            {
                return await dbSet.Where(x => x.Name.Contains(queryParams.FilterName.Trim())).OrderBy(x => x.Name).Skip(queryParams.PageSize * (queryParams.Page - 1))
                    .Take(queryParams.PageSize).ToListAsync().ConfigureAwait(true);
            }
            else if (queryParams.OrderBy == "Abrv")
            {
                return await dbSet.Where(x => x.Name.Contains(queryParams.FilterName.Trim())).OrderBy(x => x.Abrv).Skip(queryParams.PageSize * (queryParams.Page - 1))
                    .Take(queryParams.PageSize).ToListAsync().ConfigureAwait(true);
            }
            else
            {
                return await dbSet.Where(x => x.Name.Contains(queryParams.FilterName.Trim())).OrderBy(x => x.Id).Skip(queryParams.PageSize * (queryParams.Page - 1))
                    .Take(queryParams.PageSize).ToListAsync().ConfigureAwait(true);
            }
        }
    }
}
