using System.IO.Pipelines;
using TecnoShop.Models;
namespace TecnoShop.ViewModels
{
    public class ListaProductoViewModel
    {
        public IEnumerable<Producto> Productos { get; }
        public string? CategoriaActual { get; }

        public ListaProductoViewModel(IEnumerable<Producto> productos, string? categoriaActual)
        {
            Productos = productos;
            CategoriaActual = categoriaActual;
        }
    }
}
