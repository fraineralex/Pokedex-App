using Application.Services;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex_App.Controllers
{
    public class AdminPokemonsController : Controller
    {
        private readonly PokemonService _pokemonService;
        private readonly RegionService _regionService;
        private readonly PokemonTypeService _pokemonTypeService;
        private readonly EntitiesService _entitiesService;

        public AdminPokemonsController(ApplicationContext dbContext)
        {
            _pokemonService = new(dbContext);
            _regionService = new(dbContext);
            _pokemonTypeService = new(dbContext);
            _entitiesService = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Page = "adminPokemons";
            return View("AdminPokemons", await _entitiesService.GetEntitiesViewModel());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Page = "adminPokemons";
            return View("SavePokemon", new SavePokemonViewModel()
            {
                RegionList = await _regionService.GetAllViewModel(),
                PokemonTypeList = await _pokemonTypeService.GetAllViewModel()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePokemonViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.RegionList = await _regionService.GetAllViewModel();
                vm.PokemonTypeList = await _pokemonTypeService.GetAllViewModel();
                return View("SavePokemon", vm);
            }

           await _pokemonService.Add(vm);
            return RedirectToRoute(new { controller = "AdminPokemons", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Page = "adminPokemons";
            return View("SavePokemon", await _pokemonService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePokemonViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.RegionList = await _regionService.GetAllViewModel();
                vm.PokemonTypeList = await _pokemonTypeService.GetAllViewModel();
                return View("SavePokemon", vm);
            }

            await _pokemonService.Update(vm);
            return RedirectToRoute(new { controller = "AdminPokemons", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.Page = "adminPokemons";
            return View("DeletePokemon", await _pokemonService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _pokemonService.Delete(id);
            return RedirectToRoute(new { controller = "AdminPokemons", action = "Index" });
        }
    }
}
