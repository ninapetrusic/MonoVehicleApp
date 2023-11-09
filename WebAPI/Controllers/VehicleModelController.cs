using Common;
using Microsoft.AspNetCore.Mvc;
using Model;
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
        public async Task<IActionResult> GetAllModels([FromQuery] QueryParams queryParams)
        {
            IEnumerable<IVehicleModel> models = await _modelService.GetVehicleModelsAsync(queryParams);
            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModelById(int id)
        {
            IVehicleModel model = await _modelService.GetVehicleModelByIdAsync(id);
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateModel(VehicleModelCreate vehicleModel)
        {
            bool created = await _modelService.InsertVehicleModelAsync(vehicleModel);
            return (created) ? Ok(vehicleModel) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModel(int id, VehicleModelCreate vehicleModel)
        {
            await _modelService.UpdateVehicleModelAsync(id, vehicleModel);
            return Ok(vehicleModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModel(int id)
        {
            await _modelService.DeleteVehicleModelAsync(id);
            return Ok();    
        }
    }
}
