namespace TecnoShop.Models
{
    public class MarcaRepositorio : IMarcaRepositorio
    {
        private readonly TecnoShopDbContext _tecnoShopDbContext;
        public MarcaRepositorio(TecnoShopDbContext tecnoShopDbContext)
        {
            _tecnoShopDbContext = tecnoShopDbContext;
        }

        //public IEnumerable<Marca> TodasLasMarcas()
        //{
        //    List<Marca> marcas = _tecnoShopDbContext.Marcas.ToList();
        //    return marcas;
        //}


        //public IEnumerable<Marca> TodasLasMarcas
        //{
        //    get { return _tecnoShopDbContext.Marcas; }
        //}

        public IEnumerable<Marca> TodasLasMarcas => _tecnoShopDbContext.Marcas.OrderBy(m => m.MarcaId);

        

        public Marca? ObtenerMarca(int marcaId)
        {
            Marca? marca = _tecnoShopDbContext.Marcas.Where(m => m.MarcaId == marcaId).FirstOrDefault();
            return marca;
        }

        public void CrearMarca(Marca marca)
        {
            marca.Productos = new List<Producto>();
            _tecnoShopDbContext.Marcas.Add(marca);
            _tecnoShopDbContext.SaveChanges();

        }

        public void EditarMarca(Marca marca)
        {
            _tecnoShopDbContext.Marcas.Update(marca);
            _tecnoShopDbContext.SaveChanges();
        }

        public void EliminarMarca(Marca marca)
        {
            _tecnoShopDbContext.Marcas.Remove(marca);
            _tecnoShopDbContext.SaveChanges();
        }

        
    }
}
