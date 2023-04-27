using System.ComponentModel.DataAnnotations;

namespace TecnoShop.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        
        [Required(ErrorMessage = "Por favor ingrese el nombre del producto")]
        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }
        public string? Especificaciones { get; set; }
        
        [Required(ErrorMessage = "Por favor ingrese el precio del producto")]
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }
        public bool Disponible { get; set; }
        public bool Destacado { get; set; }
        public string? ImagenUrl { get; set; }

        [Required(ErrorMessage = "Por favor seleccione una marca")]
        [Display(Name = "MarcaId")]
        public int MarcaId { get; set; }
        public Marca Marca { get; set; } = default!;

        [Required(ErrorMessage = "Por favor seleccione una categoaría")]
        [Display(Name = "CategoriaId")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; } = default!;
    }
}
