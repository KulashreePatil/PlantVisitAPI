using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantVisit.EFCoreModel;
using PlantVisit.Service.Booking;

namespace PlantVisit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        readonly IBooking _service;
        public BookingController(IBooking service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Bookingmodel Bookingobj)
        {
            return Ok(await _service.Add(Bookingobj));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(Bookingmodel Bookingobj)
        {

            return Ok(await _service.Update(Bookingobj));
        }

        [HttpGet("[action]"), AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }
    }
}
