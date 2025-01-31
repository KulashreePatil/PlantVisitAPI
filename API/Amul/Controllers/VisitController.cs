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
            return Ok(await _service.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> Add(VisitModel VisitModel)
        {
            return Ok(await _service.Add(VisitModel));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(VisitModel VisitModel)
        {
            return Ok(await _service.Update(VisitModel));
           
        }

    }
}