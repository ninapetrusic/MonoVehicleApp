using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VehicleModelCreate
    {
        [Required]
        public String Name { get; set; }
        public String Abrv {  get; set; }
        [Required]
        public int VehicleMakeId { get; set; }
    }
}
