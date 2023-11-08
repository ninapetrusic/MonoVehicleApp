using AutoMapper;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Model
{
    public class VehicleMakeProfile : Profile
    {
        public VehicleMakeProfile() 
        {
            CreateMap<DAL.VehicleMake, IVehicleMake>()
                .ConstructUsing(n => new VehicleMake());
            CreateMap<IVehicleMake, DAL.VehicleMake>();
        }
    }
}
