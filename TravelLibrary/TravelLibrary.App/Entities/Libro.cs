using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TravelLibrary.App.Entities
{
    public partial class Libro
    {
        public Libro()
        {
            AutorLibros = new HashSet<AutorLibro>();
        }

        public int Id { get; set; }

        [Display(Name = "Isbn")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Isbn { get; set; }
        [Display(Name = "Titulo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Titulo { get; set; }
        [Display(Name = "Sinopsis")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Sinopsis { get; set; }
        [Display(Name = "Numero de páginas")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string NPaginas { get; set; }
        [Display(Name = "Editoriales")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione editorial.")]
        public int? EditorialesId { get; set; }

        public virtual Editorial Editoriales { get; set; }
        public virtual ICollection<AutorLibro> AutorLibros { get; set; }
    }
}
