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
        public virtual int VehicleMakeId { get; set; }
        public string Name { get; set; } = null!;
        public string? Abrv { get; set; }
        public virtual IVehicleMake VehicleMake { get; set; } = null!;

    }
}
