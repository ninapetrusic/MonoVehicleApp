using AutoMapper;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VehicleModelProfile : Profile
    {
        public VehicleModelProfile()
        {
            CreateMap<DAL.VehicleModel, IVehicleModel>()
                .ConstructUsing(n => new Model.VehicleModel());
            CreateMap<IVehicleModel, DAL.VehicleModel>();
        }
    }
}
