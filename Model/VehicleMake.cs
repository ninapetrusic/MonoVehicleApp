using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Common;

namespace Model
{
    public class VehicleMake : IVehicleMake
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Abrv {  get; set; }
        public virtual ICollection<IVehicleModel> Models {  get; } = new List<IVehicleModel>();
    }
}
