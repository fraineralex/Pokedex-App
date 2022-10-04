using Application.Services;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex_App.Controllers
{
    public class AdminRegionsController : Controller
    {
        private readonly RegionService _regionService;

        public AdminRegionsController(ApplicationContext dbContext)
        {
            _regionService = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View("AdminRegions", await _regionService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("SaveRegion", new RegionViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", vm);
            }

            await _regionService.Add(vm);
            return RedirectToRoute(new { controller = "AdminRegions", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveRegion", await _regionService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", vm);
            }

            await _regionService.Update(vm);
            return RedirectToRoute(new { controller = "AdminRegions", action = "Index" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            return View("DeleteRegion", await _regionService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _regionService.Delete(id);
            return RedirectToRoute(new { controller = "AdminRegions", action = "Index" });
        }
    }
}
