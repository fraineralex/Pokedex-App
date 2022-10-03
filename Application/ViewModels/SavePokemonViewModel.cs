using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SavePokemonViewModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Debe ingresar el nombre del pokemon")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Debe ingresar la imagen del pokemon")]
        public string? ImagePath { get; set; }
        [Required(ErrorMessage = "Debe ingresar la región del pokemon")]
        public int RegionId { get; set; }
        [Required(ErrorMessage = "Debe ingresar el tipo primario del pokemon")]
        public int PrimaryTypeId { get; set; }
        [Required(ErrorMessage = "Debe ingresar el tipo secundario del pokemon")]
        public int SecondaryTypeId { get; set; }
    }

}
