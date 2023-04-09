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

        public void CrearMarca(Marca marca)
        {
            marca.Productos = new List<Producto>();
            _tecnoShopDbContext.Marcas.Add(marca);
            _tecnoShopDbContext.SaveChanges();

        }
    }
}
