using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantVisit.EFCoreModel;
using PlantVisit.Service.Booking;


namespace PlantVisit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingTableController : ControllerBase
    {

        readonly IBooking _service;
        public BookingTableController(IBooking service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Add(BookingTable Bookingobj)
        {
            int id = await _service.Add(Bookingobj);
            return Ok("Added Successfully, Id: " + id);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(BookingTable Bookingobj)
        {
            bool updated = await _service.Update(Bookingobj);
            return Ok("Updated Successfully");
        }
        [HttpGet("[action]"), AllowAnonymous]
        public IActionResult GetAll()
        {
            List<BookingTable> lstData = _service.GetAll();
            return Ok(lstData);
        }


    }
}
