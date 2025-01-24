using Microsoft.AspNetCore.Mvc;

namespace PlantVisit.Controllers
{
    public class PlantListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
