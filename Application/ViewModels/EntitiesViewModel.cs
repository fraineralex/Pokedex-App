using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class EntitiesViewModel
    {
        public List<PokemonViewModel>? PokemonList { get; set; }
        public List<RegionViewModel>? RegionList { get; set; }
        public List<PokemonTypeViewModel>? PokemonTypeList { get; set; }
    }
}
