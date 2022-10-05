using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class PokemonTypes
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //Navigation property
        public ICollection<Pokemons> PrimaryType { get; set; }
        public ICollection<Pokemons> SecundaryType { get; set; }
    }
}
