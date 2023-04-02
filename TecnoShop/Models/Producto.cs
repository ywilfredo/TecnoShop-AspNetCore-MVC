namespace TecnoShop.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string? Nombre { get; set; }
        public string? Especificaciones { get; set; }
        public decimal? Precio { get; set; }
        public bool Disponible { get; set; }
        public bool Destacado { get; set; }
        public string? ImagenUrl { get; set; }
        public int MarcaId { get; set; }
        public Marca Marca { get; set; } = default!;
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; } = default!;
    }
}
