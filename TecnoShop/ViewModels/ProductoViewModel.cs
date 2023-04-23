using Microsoft.AspNetCore.Mvc.Rendering;
using TecnoShop.Models;

namespace TecnoShop.ViewModels
{
    public class ProductoViewModel
    {
        public Producto Producto { get; set; } = new Producto();
        public IEnumerable<Producto> Productos { get; }
        public IEnumerable<Categoria> Categorias { get; }
        public IEnumerable<Marca> Marcas { get; }
        //List<SelectListItem> CategoriaItems { get; } = new List<SelectListItem>();

        public ProductoViewModel(IEnumerable<Producto> productos, IEnumerable<Categoria> categorias, IEnumerable<Marca> marcas)
        {
            Productos = productos;
            Categorias = categorias;
            Marcas = marcas;
            //CategoriaItems = categoriaItems;
        }
    }
    
}
