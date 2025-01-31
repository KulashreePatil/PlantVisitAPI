using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantVisit.EFCoreModel;
using PlantVisit.Service.Facilities;

namespace PlantVisit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitiesController : ControllerBase
    {
        readonly IFacilities _service;
        public FacilitiesController(IFacilities service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(FacilitiesModel FacilityModel)
        {
            return Ok(await _service.Add(FacilityModel));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(FacilitiesModel FacilityModel)
        {
            bool updated = await _service.Update(FacilityModel);
            if (updated)
            {
                return Ok("Updated Successfully");
            }
            return NotFound("Facility not found or update failed.");
        }

        [HttpGet("[action]"), AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }
    }
}
