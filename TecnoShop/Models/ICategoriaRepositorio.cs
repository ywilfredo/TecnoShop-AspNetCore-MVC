namespace TecnoShop.Models
{
    public interface ICategoriaRepositorio
    {
        IEnumerable<Categoria> TodasLasCategorias();
        Categoria? ObtenerCategoria(int categoriaId);

        void CrearCategoria(Categoria categoria);

        void EditarCategoria(Categoria categoria);

        void EliminarCategoria(Categoria categoria);
    }
}
