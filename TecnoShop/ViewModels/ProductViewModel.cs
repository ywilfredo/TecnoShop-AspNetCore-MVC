using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TecnoShop.Models;

namespace TecnoShop.ViewModels
{
    public class ProductViewModel
    {
        public Producto Product { get; set; }
        public IEnumerable<Producto> Productos { get; }
        public IEnumerable<Categoria> Categorias { get;}
        public IEnumerable<Marca> Marcas { get; }
        public IFormFile? ArchivoImagen { get; set; }

        public ProductViewModel(Producto product, IEnumerable<Producto> productos, IEnumerable<Categoria> categorias, IEnumerable<Marca> marcas)
        {
            Product = product;
            Productos = productos;
            Categorias = categorias;
            Marcas = marcas;
        }
    }
}
