using Microsoft.AspNetCore.Mvc;

namespace Pokedex_App.Controllers
{
    public class AdminPokemonsController : Controller
    {
        public IActionResult AdminPokemons()
        {
            return View();
        }
    }
}
