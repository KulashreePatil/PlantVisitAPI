using Microsoft.AspNetCore.Mvc;

namespace PlantVisit.Controllers
{
    public class FacilitiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
