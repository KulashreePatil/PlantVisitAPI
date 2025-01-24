using Microsoft.AspNetCore.Mvc;

namespace PlantVisit.Controllers
{
    public class BookingTableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
