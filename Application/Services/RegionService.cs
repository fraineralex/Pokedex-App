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
    public class RegionService
    {
        private readonly RegionRepository _regionRepository;

        public RegionService(ApplicationContext dbContext)
        {
            _regionRepository = new(dbContext);
        }

        public async Task<List<RegionViewModel>> GetAllViewModel()
        {
            var regionList = await _regionRepository.GetAllAsync();
            return regionList.Select(region => new RegionViewModel
            {
                Id = region.Id,
                Name = region.Name,

            }).ToList();
        }

        public async Task Add(RegionViewModel vm)
        {
            Regions region = new();
            region.Name = vm.Name;
            await _regionRepository.AddAsync(region);
        }

        public async Task<RegionViewModel> GetByIdSaveViewModel(int id)
        {
            var region = await _regionRepository.GetByIdAsync(id);

            RegionViewModel vm = new();
            vm.Id = region.Id;
            vm.Name = region.Name;

            return vm;
        }

        public async Task Update(RegionViewModel vm)
        {
            Regions region = new();
            region.Id = vm.Id;
            region.Name = vm.Name;

            await _regionRepository.UpdateAsync(region);
        }

        public async Task Delete(int id)
        {
            var region = await _regionRepository.GetByIdAsync(id);
            await _regionRepository.DeleteAsync(region);
        }

        public async Task<RegionViewModel> GetRegionById(int id)
        {
            var region = await _regionRepository.GetByIdAsync(id);

            RegionViewModel vm = new();
            vm.Id = region.Id;
            vm.Name = region.Name;

            return vm;
        }
    }
}
