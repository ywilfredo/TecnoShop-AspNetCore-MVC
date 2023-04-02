﻿using Microsoft.EntityFrameworkCore;
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
                //retorne todas los productos incluyendo la categoria
                return _tecnoShopDbContext.Productos.Include(x => x.Categoria);
            }
        }

        public IEnumerable<Producto> ProductoDestacado
        {
            get
            {
                //Retorna todas los productos incluyendo la categoria, donde el atributo Destacado sea igual a true
                return _tecnoShopDbContext.Productos.Include(x => x.Categoria).Where(p => p.Destacado);

            }

        }

        public Producto? ObtenerProductoPorId(int productoId)
        {
            //Retorna un producto donde el atributo ProductoId sea igual al parametro
            return _tecnoShopDbContext.Productos.FirstOrDefault(p => p.ProductoId == productoId);
        }

        public IEnumerable<Producto> BuscarProductos(string searchQuery)
        {
            throw new NotImplementedException();
        }
    }
}