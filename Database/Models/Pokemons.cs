using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Pokemons
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? ImagePath { get; set; }

        // Foreign key fields

        public int RegionId { get; set; }

        public int PrimaryTypeId { get; set; }

        public int SecondaryTypeId { get; set; }

        //Navigation property
        public Regions? Regions { get; set; }
        public PokemonTypes PrimaryType { get; set; }
        public PokemonTypes SecundaryType { get; set; }
    }
}
