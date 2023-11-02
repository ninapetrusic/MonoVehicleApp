using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAllMakes()
        {
            IEnumerable<IVehicleMake> makes = await _makeService.GetVehicleMakesAsync();
            return Ok(makes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMakeById(int id)
        {
            IVehicleMake make = await _makeService.GetVehicleMakeByIdAsync(id);
            return Ok(make);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMake(IVehicleMake vehicleMake)
        {
            bool created = await _makeService.InsertVehicleMakeAsync(vehicleMake);
            return (created) ? Ok(vehicleMake) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMake(int id, IVehicleMake vehicleMake)
        {
            await _makeService.UpdateVehicleMakeAsync(id, vehicleMake);
            return Ok(vehicleMake);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMake(int id)
        {
            await _makeService.DeleteVehicleMakeAsync(id);
            return Ok();
        }
    }
}
