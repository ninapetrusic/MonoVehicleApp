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
               .ConstructUsing(vehicleModelDAL => new Model.VehicleModel(vehicleModelDAL.Id, vehicleModelDAL.Name, vehicleModelDAL.Abrv))
               .ReverseMap().ConstructUsing(vehicleModel => new DAL.VehicleModel(vehicleModel.Id, vehicleModel.Name, vehicleModel.Abrv));
            CreateMap<DbSet<IVehicleModel>, DbSet<DAL.VehicleModel>>()
                .ReverseMap();
        }
    }
}
