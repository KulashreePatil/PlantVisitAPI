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
            List<PlantModel> lstData = await _service.GetAll();
            return Ok(lstData);
        }
        [HttpPost]
        public async Task<IActionResult> Add(PlantModel PlantModel)
        {
            int added = await _service.Add(PlantModel);
            if (true)
            {
                return Ok("Added Successfully");
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(PlantModel PlantModel)
        {
            bool updated = await _service.Update(PlantModel);
            if (updated)
            {
                return Ok("Updated Successfully");
            }
            return NotFound("Plant Not Found");
        }

    }
}
