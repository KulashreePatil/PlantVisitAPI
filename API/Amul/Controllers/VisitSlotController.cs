using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantVisit.Service.VisitSlot;
using PlantVisit.EFCoreModel;
namespace PlantVisit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitSlotController : ControllerBase
    {

        readonly IVisitSlot _service;
        public VisitSlotController(IVisitSlot service)
        {
            _service = service;
        }

        [HttpGet("[action]"), AllowAnonymous]
        public IActionResult GetAll()
        {
            List<VisitSlotModel> lstData = _service.GetAll();
            return Ok(lstData);
        }
        [HttpPost]
        public async Task<IActionResult> Add(VisitSlotModel VisitSlotModel)
        {
            int id = await _service.Add(VisitSlotModel);
            return Ok("Added Successfully, Id: " + id);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(VisitSlotModel VisitSlotModel)
        {
            bool updated = await _service.Update(VisitSlotModel);
            return Ok("Updated Successfully");
        }


    }
}