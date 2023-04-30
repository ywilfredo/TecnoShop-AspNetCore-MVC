using TecnoShop.ViewModels;

namespace TecnoShop.Models
{
    public interface IProductoRepositorio
    {
        IEnumerable<Producto> TodosLosProductos { get; }
        //IEnumerable<Producto> TodosLosProductos();
        IEnumerable<Producto> ProductoDestacado { get; }
        Producto? ObtenerProductoPorId(int productoId);
        ProductoViewModel? ObtenerProducto(int id);
        IEnumerable<Producto> BuscarProductos(string searchQuery);

        public Task<int> CrearProducto(ProductoViewModel productovm);
        //public Task<int> EditarProducto(ProductCreateViewModel productovm);
        void EditarProducto(ProductoViewModel productovm);
        void EliminarProducto(Producto producto);
    }
}
