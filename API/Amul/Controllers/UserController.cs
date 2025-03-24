using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PlantVisit.EFCoreModel;
using PlantVisit.EFCoreModel.Common;
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
            return Ok(await _service.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserModel UserModel)
        {
            return Ok(await _service.Add(UserModel));
        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update(UserModel UserModel)
        {
            return Ok(await _service.Update(UserModel)); ;
        }

        [HttpGet("[action]")]
        [HttpGet("AuthenticateUser")]
        public async Task<APIResponseModel> ValidateCredential(int number, int OTP)
        {
            return await _service.ValidateCredential(number, OTP);
        }

    }
}
