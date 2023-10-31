using Microsoft.AspNetCore.Mvc;
using Model.Common;
using Service.Common;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {
        private IVehicleModelService _modelService;

        public VehicleModelController(IVehicleModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllModels()
        {
            IEnumerable<IVehicleModel> models = await _modelService.GetVehicleModelsAsync();
            return Ok(models);
        }
    }
}
