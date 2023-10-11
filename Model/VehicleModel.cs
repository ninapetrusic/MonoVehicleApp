using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VehicleModel : IVehicleModel
    {
        public int Id { get; set; }
        public int VehicleMakeId { get; set; }
        public string Name { get; set; } = null!;
        public string? Abrv { get; set; }

        public VehicleModel(string name, int vehicleMakeId) 
        {
            Name = name;
            VehicleMakeId = vehicleMakeId;
        }
        public VehicleModel(string name, string abrv, int vehicleMakeId)
        {
            Name = name;
            Abrv = abrv;
            VehicleMakeId = vehicleMakeId;
        }
    }
}
