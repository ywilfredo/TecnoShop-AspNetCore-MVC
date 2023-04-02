using Microsoft.EntityFrameworkCore;
namespace TecnoShop.Models
{
    public class TecnoShopDbContext : DbContext
    {
        public TecnoShopDbContext(DbContextOptions<TecnoShopDbContext> options) : base(options)
        {

        }

        //Estas son las tablas que van a estar en la base de datos: tiene que ser del tipo de la clase y en Plural para Las tablas
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Producto> Productos { get; set; }

    }
}
