using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TecnoShop.Models;

namespace TecnoShop.ViewModels
{
    public class ProductoViewModel
    {
        //public Producto Producto { get; set; } = new Producto();
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el nombre del producto")]
        public string Nombre { get; set; } = string.Empty;
        public string Especificaciones { get; set; } = string.Empty;

        [Required(ErrorMessage = "Por favor ingrese el precio del producto")]
        public decimal Precio { get; set; }
        public bool Disponible { get; set; }
        public bool Destacado { get; set; }
        public string? ImagenUrl { get; set; }
        public IFormFile? ArchivoImagen { get; set; }

        [Required(ErrorMessage = "Por favor seleccione una marca")]
        public int MarcaId { get; set; }
        public string NombreMarca { get; set; } = string.Empty;
        public string NombreCategoria { get; set; } = string.Empty;
        public string EstaDisponible { get; set;} = string.Empty;
        public string EsDestacado { get; set; } = string.Empty;

        [Required(ErrorMessage = "Por favor seleccione una categoaría")]
        public int CategoriaId { get; set; }
        public IEnumerable<SelectListItem>? CategoriasItems { get; set; }
        public IEnumerable<SelectListItem>? MarcasItems { get; set; }

    }
    
}
