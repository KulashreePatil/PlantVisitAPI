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
            int id = await _service.Add(FacilityModel);
            return Ok("Added Successfully, Id: " + id);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(FacilitiesModel FacilityModel)
        {
            bool updated = await _service.Update(FacilityModel);
            return Ok("Updated Successfully");
        }
        [HttpGet("[action]"),AllowAnonymous]
        public IActionResult GetAll()
        {
            List<FacilitiesModel> lstData = _service.GetAll();
            return Ok(lstData);
        }


    }
}
