using Microsoft.EntityFrameworkCore;
using TecnoShop.ViewModels;

namespace TecnoShop.Models
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly TecnoShopDbContext _tecnoShopDbContext;

        public ProductoRepositorio(TecnoShopDbContext tecnoShopDbContext)
        {
            //Al tener este atributo _tecnoShopDbContext, se esta accediendo a la base de datos.
            _tecnoShopDbContext = tecnoShopDbContext;
        }

        public IEnumerable<Producto> TodosLosProductos
        {
            get
            {
                //retorne todas los productos incluyendo la categoria y marca -- aumente el ToList() al final
                return _tecnoShopDbContext.Productos
                    .Include(p => p.Categoria)
                    .Include(p => p.Marca)
                    .OrderByDescending(p => p.ProductoId).ToList();
            }
        }

        public IEnumerable<Producto> ProductosDestacados
        {
            get
            {
                //Retorna todas los productos incluyendo la categoria, donde el atributo Destacado sea igual a true
                return _tecnoShopDbContext.Productos.Include(x => x.Categoria).Where(p => p.Destacado).ToList();

            }

        }

        public Producto? ObtenerProductoPorId(int productoId)
        {
            //Retorna un producto donde el atributo ProductoId sea igual al parametro
            return _tecnoShopDbContext.Productos.FirstOrDefault(p => p.ProductoId == productoId);
        }

        public async Task<int> CrearProducto(ProductoViewModel productoVM)
        {
            var producto = new Producto()
            {
                Nombre = productoVM.Nombre,
                Especificaciones = productoVM.Especificaciones,
                Precio = productoVM.Precio,
                Disponible = productoVM.Disponible,
                Destacado = productoVM.Destacado,
                ImagenUrl = productoVM.ImagenUrl,
                MarcaId = productoVM.MarcaId,
                CategoriaId = productoVM.CategoriaId
            };
            await _tecnoShopDbContext.Productos.AddAsync(producto);
             await _tecnoShopDbContext.SaveChangesAsync();
            return producto.ProductoId;
        }


        public ProductoViewModel? ObtenerProducto(int id)
        {
            return _tecnoShopDbContext.Productos.Where(p => p.ProductoId == id)
                .Select(producto => new ProductoViewModel()
                {
                    ProductoId = producto.ProductoId,
                    Nombre = producto.Nombre,
                    Especificaciones = producto.Especificaciones,
                    Precio = producto.Precio,
                    Disponible = producto.Disponible,
                    Destacado = producto.Destacado,
                    ImagenUrl = producto.ImagenUrl,
                    CategoriaId = producto.CategoriaId,
                    MarcaId = producto.MarcaId
                }).FirstOrDefault();
        }



        public void EditarProducto(ProductoViewModel productoVM)
        {
            var producto = new Producto()
            {
                ProductoId= productoVM.ProductoId,
                Nombre = productoVM.Nombre,
                Especificaciones = productoVM.Especificaciones,
                Precio = productoVM.Precio,
                Disponible = productoVM.Disponible,
                Destacado = productoVM.Destacado,
                ImagenUrl = productoVM.ImagenUrl,
                MarcaId = productoVM.MarcaId,
                CategoriaId = productoVM.CategoriaId
            };
             _tecnoShopDbContext.Productos.Update(producto);
             _tecnoShopDbContext.SaveChanges();
            

        }

        public void EliminarProducto(Producto producto)
        {
            _tecnoShopDbContext.Productos.Remove(producto);
            _tecnoShopDbContext.SaveChanges();
        }

    }
}
