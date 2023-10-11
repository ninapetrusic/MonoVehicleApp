using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Common
{
    public interface IVehicleMake
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Abrv { get; set; }
    }
}
