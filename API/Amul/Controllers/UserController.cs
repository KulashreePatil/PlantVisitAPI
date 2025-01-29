using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantVisit.EFCoreModel;
using PlantVisit.Service.User;


namespace PlantVisit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        readonly IUser _service;
        public UserController(IUser service)
        {
            _service = service;
        }

        [HttpGet("[action]"), AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            List<UserModel> lstData = await _service.GetAll();
            return Ok(lstData);
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserModel UserModel)
        {
            int id = await _service.Add(UserModel);
            return Ok("Added Successfully, Id: " + id);
        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update(UserModel UserModel)
        {
            bool updated = await _service.Update(UserModel);
            if (updated)
            {
                return Ok("Updated Successfully");
            }
            return NotFound("Plant Not Found");
        }


    }
}
