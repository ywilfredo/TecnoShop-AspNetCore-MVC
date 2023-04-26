using Microsoft.AspNetCore.Mvc.Rendering;
using TecnoShop.Models;

namespace TecnoShop.ViewModels
{
    public class ProductCreateViewModel
    {
        //public Producto Producto { get; set; } = new Producto();

        public string? Nombre { get; set; }
        public string? Especificaciones { get; set; }
        public decimal? Precio { get; set; }
        public bool Disponible { get; set; }
        public bool Destacado { get; set; }
        public IFormFile ImageFile { get; set; }
        public int MarcaId { get; set; }
        public int CategoriaId { get; set; }
        public IEnumerable<SelectListItem>? CategoriasItems { get; set; }
        public IEnumerable<SelectListItem>? MarcasItems { get; set; }

    }
    
}
