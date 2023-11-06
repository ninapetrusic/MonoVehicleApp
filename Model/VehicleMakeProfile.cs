using AutoMapper;
using DAL;
using Microsoft.EntityFrameworkCore;
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
               .ConstructUsing(vehicleMakeDAL => new Model.VehicleMake(vehicleMakeDAL.Id, vehicleMakeDAL.Name, vehicleMakeDAL.Abrv))
               .ReverseMap().ConstructUsing(vehicleMake => new DAL.VehicleMake(vehicleMake.Id, vehicleMake.Name, vehicleMake.Abrv));
        }
    }
}
