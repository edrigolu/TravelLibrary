using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TravelLibrary.App.Entities
{
    public partial class Autor
    {
        public Autor()
        {
            AutorLibros = new HashSet<AutorLibro>();
        }

        public int Id { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombre { get; set; }
        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Apellido { get; set; }

        public virtual ICollection<AutorLibro> AutorLibros { get; set; }
    }
}
