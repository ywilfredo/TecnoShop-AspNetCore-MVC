namespace TecnoShop.Models
{
    public interface ICategoriaRepositorio
    {
        IEnumerable<Categoria> TodasLasCategorias { get; }


        void CrearCategoria(Categoria categoria);

        //void ActualizarCategoria(Categoria categoria);

        //void EliminarCategoria(Categoria categoria);
    }
}
