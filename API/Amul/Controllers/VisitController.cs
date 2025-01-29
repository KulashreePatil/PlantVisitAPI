using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantVisit.Service.Visit;
using PlantVisit.EFCoreModel;
namespace PlantVisit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {

        readonly IVisit _service;
        public VisitController(IVisit service)
        {
            _service = service;
        }

        [HttpGet("[action]"), AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            List<VisitModel> lstData = await _service.GetAll();
            return Ok(lstData);
        }
        [HttpPost]
        public async Task<IActionResult> Add(VisitModel VisitModel)
        {
            int id = await _service.Add(VisitModel);
            return Ok("Added Successfully, Id: " + id);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(VisitModel VisitModel)
        {
            bool updated = await _service.Update(VisitModel);
            if (updated)
            {
                return Ok("Updated Successfully");
            }
            return NotFound("Visit Not Found");
        }

    }
}