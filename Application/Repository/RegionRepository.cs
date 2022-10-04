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
    public class RegionRepository
    {
        private readonly ApplicationContext _dbContext;

        public RegionRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Regions region)
        {
            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Regions region)
        {
            _dbContext.Entry(region).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Regions region)
        {
            _dbContext.Set<Regions>().Remove(region);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Regions>> GetAllAsync()
        {
            return await _dbContext.Set<Regions>().ToListAsync();
        }
        public async Task<Regions> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Regions>().FindAsync(id);
        }
    }
}
