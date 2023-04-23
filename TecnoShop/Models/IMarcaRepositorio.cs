namespace TecnoShop.Models
{
    public interface IMarcaRepositorio
    {
        IEnumerable<Marca> TodasLasMarcas { get; }
        Marca? ObtenerMarca(int marcaId);

        void CrearMarca(Marca marca);

        void EditarMarca(Marca marca);

        void EliminarMarca(Marca marca);
    }
}
