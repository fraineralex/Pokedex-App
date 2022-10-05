using Application.Services;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pokedex_App.Models;
using System.Diagnostics;

namespace Pokedex_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly PokemonService _pokemonService;
        private readonly RegionService _regionService;

        public HomeController(ApplicationContext dbContext)
        {
            _pokemonService = new(dbContext);
            _regionService = new(dbContext);
        }

        public async Task<IActionResult> Index(FilterViewModel vm)
        {
            ViewBag.RegionList = await _regionService.GetAllViewModel();
            ViewBag.Page = "home";
            return View(await _pokemonService.GetAllViewModelWithFilters(vm));
        }
    }
}