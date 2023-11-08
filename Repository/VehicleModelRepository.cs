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
    public class VehicleModelRepository : GenericRepository<DAL.VehicleModel>, IVehicleModelRepository
    {
        public VehicleModelRepository(IMapper _mapper, VehicleContext context) : base(context, _mapper)
        {
        }
    }
}
