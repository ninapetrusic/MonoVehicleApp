using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Common
{
    public interface IVehicleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Abrv { get; set; }
        public int VehicleMakeId { get; set; }
        public IVehicleMake VehicleMake { get; set; }  
    }
}
