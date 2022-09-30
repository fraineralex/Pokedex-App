using Microsoft.AspNetCore.Mvc;

namespace Pokedex_App.Controllers
{
    public class AdminRegionsController : Controller
    {
        public IActionResult AdminRegions()
        {
            return View();
        }
    }
}
