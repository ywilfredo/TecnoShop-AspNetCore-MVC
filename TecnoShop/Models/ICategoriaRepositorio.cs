namespace TecnoShop.Models
{
    public interface ICategoriaRepositorio
    {
        IEnumerable<Categoria> TodasLasCategorias { get; }
    }
}
