namespace TecnoShop.Models
{
    public interface IProductoRepositorio
    {
        IEnumerable<Producto> TodosLosProductos { get; }
        IEnumerable<Producto> ProductoDestacado { get; }
        Producto? ObtenerProductoPorId(int productoId);
        IEnumerable<Producto> BuscarProductos(string searchQuery);
    }
}
