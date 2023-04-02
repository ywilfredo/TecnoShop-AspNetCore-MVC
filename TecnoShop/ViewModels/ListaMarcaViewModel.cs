using TecnoShop.Models;

namespace TecnoShop.ViewModels
{
    public class ListaMarcaViewModel
    {
        public IEnumerable<Marca> Marcas { get; }

        public ListaMarcaViewModel(IEnumerable<Marca> marcas)
        {
            Marcas = marcas;
        }
    }
}
