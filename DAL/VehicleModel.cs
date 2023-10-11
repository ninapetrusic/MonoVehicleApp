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

        public int Id {  get; set; }
        public VehicleMake VehicleMake { get; set; } = null!;
        public int VehicleMakeId { get; set; } 
        public string Name { get; set; } = null!;
        public string? Abrv { get; set; }   
    }
}
