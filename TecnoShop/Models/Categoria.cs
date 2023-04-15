using System.ComponentModel.DataAnnotations;
using System.IO.Pipelines;
using System.Xml.Linq;

namespace TecnoShop.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        [Required(ErrorMessage = "Por favor ingrese el nombre de la categoría")]
        [Display(Name = "Nombre")]
        [StringLength(50)]

        public string Nombre { get; set; } = string.Empty;
        
        [Display(Name = "Descripcion")]
        public string? Descripcion { get; set; }
        public List<Producto>? Productos { get; set; }

    }
}
