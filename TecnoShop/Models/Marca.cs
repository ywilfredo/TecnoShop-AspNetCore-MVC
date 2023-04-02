namespace TecnoShop.Models
{
    public class Marca
    {
        public int MarcaId { get; set; }
        public string Nombre { get; set; } = default!;
        public string? Descripcion { get; set; }
        public List<Producto>? Productos { get; set; }
    }
}
