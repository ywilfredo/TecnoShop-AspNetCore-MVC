using Microsoft.AspNetCore.Mvc.Rendering;

namespace TecnoShop.Models
{
    public interface ICategoriaRepositorio
    {
        IEnumerable<Categoria> TodasLasCategorias { get; }
        Categoria? ObtenerCategoria(int categoriaId);
        List<SelectListItem> CategoriaItems();

        void CrearCategoria(Categoria categoria);

        void EditarCategoria(Categoria categoria);

        void EliminarCategoria(Categoria categoria);
    }
}
