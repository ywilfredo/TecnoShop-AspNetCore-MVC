namespace TecnoShop.Models
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly TecnoShopDbContext _tecnoShopDbContext;
        public CategoriaRepositorio(TecnoShopDbContext tecnoShopDbContext)
        {
            _tecnoShopDbContext = tecnoShopDbContext;
        }
        public IEnumerable<Categoria> TodasLasCategorias => _tecnoShopDbContext.Categorias.OrderBy(x => x.Nombre);

    }
}
