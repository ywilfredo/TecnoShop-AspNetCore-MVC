using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO.Pipelines;
using TecnoShop.Models;
namespace TecnoShop.ViewModels
{
    public class ListaProductoViewModel
    {
        public IEnumerable<Producto> Productos { get; }

        public ListaProductoViewModel(IEnumerable<Producto> productos)
        {
            Productos = productos;

        }
        
    }
}
