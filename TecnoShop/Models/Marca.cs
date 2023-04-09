using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TecnoShop.Models
{
    public class Marca
    {
        public int MarcaId { get; set; }
        [Required(ErrorMessage = "Por favor ingrese el nombre de la marca")]
        [Display(Name = "Nombre de la marca")]
        [StringLength(50)]

        public string Nombre { get; set; } = default!;

        [Display(Name = "Descripcion")]
        public string? Descripcion { get; set; }
        public List<Producto>? Productos { get; set; }

     }
}
