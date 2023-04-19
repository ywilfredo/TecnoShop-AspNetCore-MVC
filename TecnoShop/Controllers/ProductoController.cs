using Microsoft.AspNetCore.Mvc;
using TecnoShop.Models;
using TecnoShop.ViewModels;

namespace TecnoShop.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoRepositorio _productoRepositorio;
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IMarcaRepositorio _marcaRepositorio;

        public ProductoController(IProductoRepositorio productoRepositorio, ICategoriaRepositorio categoriaRepositorio, IMarcaRepositorio marcaRepositorio)
        {
            _productoRepositorio = productoRepositorio;
            _categoriaRepositorio = categoriaRepositorio;
            _marcaRepositorio = marcaRepositorio;
        }

        public IActionResult Index()
        {
            IEnumerable<Producto> productos = _productoRepositorio.TodosLosProductos.ToList();
            return View(productos);
        }

        public IActionResult ListaProducto()
        {

            ListaProductoViewModel listaProductoViewModel = new ListaProductoViewModel(_productoRepositorio.TodosLosProductos,"Gaming");
            return View(listaProductoViewModel);
        }

        public IActionResult Especificacion(int id) // el id tiene que se er mismo que en la vista. 
        {
            var producto = _productoRepositorio.ObtenerProductoPorId(id);
            if (producto == null)
                return NotFound();
            return View(producto);
        }
    }
}
