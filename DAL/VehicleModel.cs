using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Abrv { get; set; }
        public virtual int VehicleMakeId { get; set; }
        [ForeignKey("VehicleMakeId")]
        public virtual VehicleMake VehicleMake { get; set; } = null!;

    }
}
