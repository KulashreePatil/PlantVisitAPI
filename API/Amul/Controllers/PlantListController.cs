using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantVisit.Service.Plant;
using PlantVisit.EFCoreModel;
namespace PlantVisit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantListController : ControllerBase
    {

        readonly IPlantList _service;
        public PlantListController(IPlantList service)
        {
            _service = service;
        }

        [HttpGet("[action]"), AllowAnonymous]
        public IActionResult GetAll()
        {
            List<PlantListModel> lstData = _service.GetAll();
            return Ok(lstData);
        }
        [HttpPost]
        public async Task<IActionResult> Add(PlantListModel PlantListModel)
        {
            int id = await _service.Add(PlantListModel);
            return Ok("Added Successfully, Id: " + id);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(PlantListModel PlantListModel)
        {
            bool updated = await _service.Update(PlantListModel);
            return Ok("Updated Successfully");
        }


    }
}
