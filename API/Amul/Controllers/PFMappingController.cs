using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantVisit.EFCoreModel;
using PlantVisit.Service.PFMap;


namespace PlantVisit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PFMappingController : ControllerBase
    {

        readonly IPFMapping _service;
        public PFMappingController(IPFMapping service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Add(PFMappingmodel obj)
        {
            int id = await _service.Add(obj);
            return Ok("Added Successfully, Id: " + id);
        }
        [HttpGet("[action]"), AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            List<PFMappingmodel> lstData = await _service.GetAll();
            return Ok(lstData);
        }


    }
}
