using Application.Repository;
using Application.ViewModels;
using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PokemonService
    {
        private readonly PokemonRepository _pokemonRepository;
        private readonly RegionService _regionService;
        private PokemonTypeService _pokemonTypeService;

        public PokemonService(ApplicationContext dbContext)
        {
            _pokemonRepository = new(dbContext);
            _regionService = new(dbContext);
            _pokemonTypeService = new(dbContext);
        }

        public async Task<List<PokemonViewModel>> GetAllViewModel()
        {
            var pokemonList = await _pokemonRepository.GetAllAsync();
            return pokemonList.Select(pokemon => new PokemonViewModel
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                ImagePath = pokemon.ImagePath,
                Region = pokemon.Regions.Name,
                TypePrimary = pokemon.PrimaryType.Name,
                TypeSecondary = pokemon.SecundaryType.Name,

            }).ToList();
        }

        public async Task Add(SavePokemonViewModel vm)
        {
            Pokemons pokemon = new();
            pokemon.Name = vm.Name;
            pokemon.ImagePath = vm.ImagePath;
            pokemon.RegionId = vm.RegionId;
            pokemon.PrimaryTypeId = vm.PrimaryTypeId;
            pokemon.SecondaryTypeId = vm.SecondaryTypeId;
            await _pokemonRepository.AddAsync(pokemon);
        }

        public async Task<SavePokemonViewModel> GetByIdSaveViewModel(int id)
        {
            var pokemon = await GetPokemonById(id);

            SavePokemonViewModel vm = new();
            vm.Id = pokemon.Id;
            vm.Name = pokemon.Name;
            vm.ImagePath = pokemon.ImagePath;
            vm.RegionId = pokemon.RegionId;
            vm.PrimaryTypeId = pokemon.PrimaryTypeId;
            vm.SecondaryTypeId = pokemon.SecondaryTypeId;
            vm.PokemonTypeList = await _pokemonTypeService.GetAllViewModel();
            vm.RegionList = await _regionService.GetAllViewModel();

            return vm;
        }

        public async Task Update(SavePokemonViewModel vm)
        {
            Pokemons pokemon = new();
            pokemon.Id = vm.Id;
            pokemon.Name = vm.Name;
            pokemon.ImagePath = vm.ImagePath;
            pokemon.RegionId = vm.RegionId;
            pokemon.PrimaryTypeId = vm.PrimaryTypeId;
            pokemon.SecondaryTypeId = vm.SecondaryTypeId;

            await _pokemonRepository.UpdateAsync(pokemon);
        }

        public async Task Delete(int id)
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(id);
            await _pokemonRepository.DeleteAsync(pokemon);
        }

        public async Task<SavePokemonViewModel> GetPokemonById(int id)
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(id);

            SavePokemonViewModel vm = new()
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                ImagePath = pokemon.ImagePath,
                RegionId = pokemon.RegionId,
                PrimaryTypeId = pokemon.PrimaryTypeId,
                SecondaryTypeId = pokemon.SecondaryTypeId
            };

            return vm;
        }

        public async Task<List<PokemonViewModel>> GetAllViewModelWithFilters(FilterViewModel vm)
        {
            var pokemonList = await _pokemonRepository.GetAllAsync();
            var pokemonViewModelList = pokemonList.Select(pokemon => new PokemonViewModel
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                ImagePath = pokemon.ImagePath,
                Region = pokemon.Regions.Name,
                TypePrimary = pokemon.PrimaryType.Name,
                TypeSecondary = pokemon.SecundaryType.Name,
                RegionId = pokemon.Regions.Id,

            }).ToList();

            if (vm.RegionId != null)
            {
                pokemonViewModelList = pokemonViewModelList
                    .Where(pokemon => pokemon.RegionId == vm.RegionId.Value)
                    .ToList();
            }

            if (!String.IsNullOrEmpty(vm.PokemonName))
            {
                pokemonViewModelList = pokemonViewModelList
                    .Where(pokemon => pokemon.Name.Contains(vm.PokemonName))
                    .ToList();
            }

            return pokemonViewModelList;
        }

    }


}
