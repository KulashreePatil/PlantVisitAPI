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
            int id = await _service.Add(Bookingobj);
            if (id > 0)
            {
                return Ok("Added Successfully, Id: " + id);
            }
            return BadRequest("Error adding booking.");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(Bookingmodel Bookingobj)
        {
            bool updated = await _service.Update(Bookingobj);
            if (updated)
            {
                return Ok("Updated Successfully");
            }
            return NotFound("Booking not found or update failed.");
        }

        [HttpGet("[action]"), AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var lstData = await _service.GetAll();  
            return Ok(lstData);  
        }
    }
}
