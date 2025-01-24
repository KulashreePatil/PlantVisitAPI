using Microsoft.AspNetCore.Mvc;

namespace PlantVisit.Controllers
{
    public class UserDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
