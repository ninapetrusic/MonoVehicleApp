using Common;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Common;
using Service.Common;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMakeController : ControllerBase
    {
        private IVehicleMakeService _makeService;
        public VehicleMakeController(IVehicleMakeService makeService)
        {
            _makeService = makeService;
        }
        [HttpGet]  
        public async Task<IActionResult> GetAllMakes([FromQuery] QueryParams queryParams)
        {
            IEnumerable<IVehicleMake> makes = await _makeService.GetVehicleMakesAsync(queryParams);
            return Ok(makes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMakeById(int id)
        {
            IVehicleMake make = await _makeService.GetVehicleMakeByIdAsync(id);
            return Ok(make);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMake(VehicleMakeCreate vehicleMake)
        {
            bool created = await _makeService.InsertVehicleMakeAsync(vehicleMake);
            return (created) ? Ok(vehicleMake) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMake(int id, VehicleMakeCreate vehicleMake)
        {
            bool updated = await _makeService.UpdateVehicleMakeAsync(id, vehicleMake);
            return (updated) ?  Ok(vehicleMake) : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMake(int id)
        {
            bool deleted = await _makeService.DeleteVehicleMakeAsync(id);
            return (deleted) ? Ok() : BadRequest();
        }
    }
}
