using TecnoShop.ViewModels;

namespace TecnoShop.Models
{
    public interface IProductoRepositorio
    {
        IEnumerable<Producto> TodosLosProductos { get; }
        //IEnumerable<Producto> TodosLosProductos();
        IEnumerable<Producto> ProductosDestacados { get; }
        Producto? ObtenerProductoPorId(int productoId);
        ProductoViewModel? ObtenerProducto(int id);
        public Task<int> CrearProducto(ProductoViewModel productovm);
        void EditarProducto(ProductoViewModel productovm);
        void EliminarProducto(Producto producto);
    }
}
