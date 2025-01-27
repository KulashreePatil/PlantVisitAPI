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

        [HttpGet("[action]"), AllowAnonymous]
        public IActionResult GetAll()
        {
            List<PFMappingmodel> lstData = _service.GetAll();
            return Ok(lstData);
        }


    }
}
