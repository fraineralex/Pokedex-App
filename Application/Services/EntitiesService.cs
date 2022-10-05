using Application.Services;
using Application.ViewModels;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EntitiesService
    {
        private readonly PokemonService _pokemonService;
        private readonly RegionService _regionService;
        private readonly PokemonTypeService _pokemonTypeService;

        public EntitiesService(ApplicationContext dbContext)
        {
            _pokemonService = new PokemonService(dbContext);
            _regionService = new RegionService(dbContext);
            _pokemonTypeService = new PokemonTypeService(dbContext);
        }

        public async Task<EntitiesViewModel> GetEntitiesViewModel()
        {
            return new EntitiesViewModel()
            {
                PokemonList = await _pokemonService.GetAllViewModel(),
                RegionList = await _regionService.GetAllViewModel(),
                PokemonTypeList = await _pokemonTypeService.GetAllViewModel()
            };
        }
    }
}
