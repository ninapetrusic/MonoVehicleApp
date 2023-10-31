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
    }
}
