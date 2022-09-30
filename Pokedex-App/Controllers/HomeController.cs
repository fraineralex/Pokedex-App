using Application.Services;
using Database;
using Microsoft.AspNetCore.Mvc;
using Pokedex_App.Models;
using System.Diagnostics;

namespace Pokedex_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly PokemonService _pokemonService;

        public HomeController(ApplicationContext dbContext)
        {
            _pokemonService = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pokemonService.GetAllViewModel());
        }
    }
}