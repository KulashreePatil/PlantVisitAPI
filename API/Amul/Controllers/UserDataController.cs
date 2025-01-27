using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantVisit.EFCoreModel;
using PlantVisit.Service.UserDta;


namespace PlantVisit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {

        readonly IUserData _service;
        public UserDataController(IUserData service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserDatamodel objuser)
        {
            int id = await _service.Add(objuser);
            return Ok("Added Successfully, Id: " + id);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UserDatamodel objuser)
        {
            int updated = await _service.Update(objuser);
            return Ok("Updated Successfully");
        }
        [HttpGet("[action]"), AllowAnonymous]
        public IActionResult GetAll()
        {
            List<UserDatamodel> lstData = _service.GetAll();
            return Ok(lstData);
        }


    }
}
