using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Regions
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //Navigation property
        public ICollection<Pokemons> Pokemons { get; set; }
    }
}
