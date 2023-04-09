using TecnoShop.Models;

namespace TecnoShop.ViewModels
{
    public class ListaCategoriaViewModel
    {
        public IEnumerable<Categoria> Categorias { get; }

        public ListaCategoriaViewModel(IEnumerable<Categoria> categorias)
        {
            Categorias = categorias;
        }

    }
}
