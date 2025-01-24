using Microsoft.AspNetCore.Mvc;

namespace PlantVisit.Controllers
{
    public class VisitSlotController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
