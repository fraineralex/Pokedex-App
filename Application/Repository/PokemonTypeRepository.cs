using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class PokemonTypeRepository
    {
        private readonly ApplicationContext _dbContext;

        public PokemonTypeRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(PokemonTypes pokemonType)
        {
            await _dbContext.PokemonTypes.AddAsync(pokemonType);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(PokemonTypes pokemonType)
        {
            _dbContext.Entry(pokemonType).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(PokemonTypes pokemonType)
        {
            _dbContext.Set<PokemonTypes>().Remove(pokemonType);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<PokemonTypes>> GetAllAsync()
        {
            return await _dbContext.Set<PokemonTypes>().ToListAsync();
        }
        public async Task<PokemonTypes> GetByIdAsync(int id)
        {
            return await _dbContext.Set<PokemonTypes>().FindAsync(id);
        }
    }
}
