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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModelById(int id)
        {
            IVehicleModel model = await _modelService.GetVehicleModelByIdAsync(id);
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateModel(IVehicleModel vehicleModel)
        {
            bool created = await _modelService.InsertVehicleModelAsync(vehicleModel);
            return (created) ? Ok(vehicleModel) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModel(int id, IVehicleModel vehicleModel)
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
