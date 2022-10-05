using Application.Services;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex_App.Controllers
{
    public class AdminPokemonTypesController : Controller
    {
        private readonly PokemonTypeService _pokemonTypeService;

        public AdminPokemonTypesController(ApplicationContext dbContext)
        {
            _pokemonTypeService = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Page = "adminPokemonTypes";
            return View("AdminPokemonTypes", await _pokemonTypeService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            ViewBag.Page = "adminPokemonTypes";
            return View("SavePokemonType", new PokemonTypeViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(PokemonTypeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemonType", vm);
            }

            await _pokemonTypeService.Add(vm);
            return RedirectToRoute(new { controller = "AdminPokemonTypes", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Page = "adminPokemonTypes";
            return View("SavePokemonType", await _pokemonTypeService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PokemonTypeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemonType", vm);
            }

            await _pokemonTypeService.Update(vm);
            return RedirectToRoute(new { controller = "AdminPokemonTypes", action = "Index" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.Page = "adminPokemonTypes";
            return View("DeletePokemonType", await _pokemonTypeService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _pokemonTypeService.Delete(id);
            return RedirectToRoute(new { controller = "AdminPokemonTypes", action = "Index" });
        }
    }
}
