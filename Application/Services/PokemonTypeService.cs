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
    public class PokemonTypeService
    {
        private readonly PokemonTypeRepository _pokemonTypeRepository;

        public PokemonTypeService(ApplicationContext dbContext)
        {
            _pokemonTypeRepository = new(dbContext);
        }

        public async Task<List<PokemonTypeViewModel>> GetAllViewModel()
        {
            var pokemonList = await _pokemonTypeRepository.GetAllAsync();
            return pokemonList.Select(pokemonType => new PokemonTypeViewModel
            {
                Id = pokemonType.Id,
                Name = pokemonType.Name,

            }).ToList();
        }

        public async Task Add(PokemonTypeViewModel vm)
        {
            PokemonTypes pokemonType = new();
            pokemonType.Name = vm.Name;
            await _pokemonTypeRepository.AddAsync(pokemonType);
        }

        public async Task<PokemonTypeViewModel> GetByIdSaveViewModel(int id)
        {
            var pokemonType = await _pokemonTypeRepository.GetByIdAsync(id);

            PokemonTypeViewModel vm = new();
            vm.Id = pokemonType.Id;
            vm.Name = pokemonType.Name;

            return vm;
        }

        public async Task Update(PokemonTypeViewModel vm)
        {
            PokemonTypes pokemonType = new();
            pokemonType.Id = vm.Id;
            pokemonType.Name = vm.Name;

            await _pokemonTypeRepository.UpdateAsync(pokemonType);
        }

        public async Task Delete(int id)
        {
            var pokemonType = await _pokemonTypeRepository.GetByIdAsync(id);
            await _pokemonTypeRepository.DeleteAsync(pokemonType);
        }

    }


}
