using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantVisit.Service.Plant;
using PlantVisit.EFCoreModel;
namespace PlantVisit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : ControllerBase
    {

        readonly IPlant _service;
        public PlantController(IPlant service)
        {
            _service = service;
        }

        [HttpGet("[action]"), AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> Add(PlantModel PlantModel)
        {
            return Ok(await _service.Add(PlantModel));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(PlantModel PlantModel)
        {

            return Ok(await _service.Update(PlantModel));
        }

    }
}
