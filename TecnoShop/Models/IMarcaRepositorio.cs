namespace TecnoShop.Models
{
    public interface IMarcaRepositorio
    {
        IEnumerable<Marca> TodasLasMarcas { get; }
    }
}
