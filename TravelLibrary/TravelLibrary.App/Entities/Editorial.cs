using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TravelLibrary.App.Entities
{
    public partial class Editorial
    {
        public Editorial()
        {
            Libros = new HashSet<Libro>();
        }

        public int Id { get; set; }
        [Display(Name = "Editorial")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombre { get; set; }
        [Display(Name = "Sede")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Sede { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
