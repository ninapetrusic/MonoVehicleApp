using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VehicleMake
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Abrv { get; set; }
    }
}
