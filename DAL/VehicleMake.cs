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
        public VehicleMake(int id, string name, string? abrv)
        {
            Id = id;
            Name = name;
            Abrv = abrv;
        }

        public VehicleMake(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
