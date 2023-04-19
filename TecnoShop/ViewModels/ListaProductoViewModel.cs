using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO.Pipelines;
using TecnoShop.Models;
namespace TecnoShop.ViewModels
{
    public class ListaProductoViewModel
    {
        public IEnumerable<Producto> Productos { get; }
        //public IEnumerable<SelectListItem> Categorias { get; }
        public string? CategoriaActual { get; }
        

        public ListaProductoViewModel(IEnumerable<Producto> productos, string? categoriaActual)
        {
            Productos = productos;
            CategoriaActual = categoriaActual;
        }

        
    }
}
