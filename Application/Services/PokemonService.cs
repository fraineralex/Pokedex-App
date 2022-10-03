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

        public PokemonService(ApplicationContext dbContext)
        {
            _pokemonRepository = new(dbContext);
        }

        public async Task<List<PokemonViewModel>> GetAllViewModel()
        {
            var pokemonList = await _pokemonRepository.GetAllAsync();
            return pokemonList.Select(pokemon => new PokemonViewModel
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                ImagePath = pokemon.ImagePath,

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
            var pokemon = await _pokemonRepository.GetByIdAsync(id);

            SavePokemonViewModel vm = new();
            vm.Id = pokemon.Id;
            vm.Name = pokemon.Name;
            vm.ImagePath = pokemon.ImagePath;
            vm.RegionId = pokemon.RegionId;
            vm.PrimaryTypeId = pokemon.PrimaryTypeId;
            vm.SecondaryTypeId = pokemon.SecondaryTypeId;

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

    }


}
