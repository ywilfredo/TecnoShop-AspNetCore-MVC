using TecnoShop.ViewModels;

namespace TecnoShop.Models
{
    public interface IProductoRepositorio
    {
        IEnumerable<Producto> TodosLosProductos { get; }
        //IEnumerable<Producto> TodosLosProductos();
        IEnumerable<Producto> ProductoDestacado { get; }
        Producto? ObtenerProductoPorId(int productoId);
        IEnumerable<Producto> BuscarProductos(string searchQuery);

        public Task<int> CrearProducto(ProductCreateViewModel productovm);
        void EditarProducto(Producto producto);
    }
}
