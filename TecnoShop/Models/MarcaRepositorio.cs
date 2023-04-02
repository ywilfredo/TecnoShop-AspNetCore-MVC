namespace TecnoShop.Models
{
    public class MarcaRepositorio : IMarcaRepositorio
    {
        private readonly TecnoShopDbContext _tecnoShopDbContext;
        public MarcaRepositorio(TecnoShopDbContext tecnoShopDbContext)
        {
            _tecnoShopDbContext = tecnoShopDbContext;
        }
        public IEnumerable<Marca> TodasLasMarcas => _tecnoShopDbContext.Marcas.OrderBy(x => x.Nombre);
    }
}
