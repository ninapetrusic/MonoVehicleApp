using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public VehicleMake VehicleMake { get; set; } = null!;
        public int VehicleMakeId { get; set; }
        public string Name { get; set; } = null!;
        public string? Abrv { get; set; }
        private VehicleModel()
        {
        }

        public VehicleModel(int id, string name, string? abrv)
        {
            Id = id;
            Name = name;
            Abrv = abrv;
        }

        public VehicleModel(int id, string name, int vehicleMakeId)
        {
            Id = id;
            VehicleMakeId = vehicleMakeId;
            Name = name;
        }

        public VehicleModel(int id, string name, string? abrv, int vehicleMakeId)
        {
            Id = id;
            VehicleMakeId = vehicleMakeId;
            Name = name;
            Abrv = abrv;
        }
    }
}
