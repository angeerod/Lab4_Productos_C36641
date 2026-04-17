using System.ComponentModel.DataAnnotations;

namespace Laboratorio04.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es requerido")]
        [Range(0.01, 999999, ErrorMessage = "El precio debe estar entre 0.01 y 999999")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "La categoría es requerida")]
        public string Categoria { get; set; } = string.Empty;
    }
}
