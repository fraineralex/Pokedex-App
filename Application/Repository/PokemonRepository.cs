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
    public class PokemonRepository
    {
        private readonly ApplicationContext _dbContext;

        public PokemonRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Pokemons pokemon)
        {
            await _dbContext.Pokemons.AddAsync(pokemon);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Pokemons pokemon)
        {
            _dbContext.Entry(pokemon).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Pokemons pokemon)
        {
            _dbContext.Set<Pokemons>().Remove(pokemon);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Pokemons>> GetAllAsync()
        {
            return await _dbContext.Set<Pokemons>().ToListAsync();
        }
        public async Task<Pokemons> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Pokemons>().FindAsync(id);
        }
    }
}
