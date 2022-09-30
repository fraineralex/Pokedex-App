using Microsoft.AspNetCore.Mvc;

namespace Pokedex_App.Controllers
{
    public class AdminPokemonTypesController : Controller
    {
        public IActionResult AdminPokemonTypes()
        {
            return View();
        }
    }
}
