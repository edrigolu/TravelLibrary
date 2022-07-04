#nullable disable

using System.ComponentModel.DataAnnotations;

namespace TravelLibrary.App.Entities
{
    public partial class AutorLibro
    {
        public int Id { get; set; }
        [Display(Name = "Autor")]
        public int? AutoresId { get; set; }
        [Display(Name = "Titulo")]
        public int? LibrosId { get; set; }

        public virtual Autor Autores { get; set; }
        public virtual Libro Libros { get; set; }
    }
}
