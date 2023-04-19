namespace TecnoShop.Models
{
    public interface IMarcaRepositorio
    {
        IEnumerable<Marca> TodasLasMarcas();
        Marca? ObtenerMarca(int marcaId);

        void CrearMarca(Marca marca);

        void EditarMarca(Marca marca);

        void EliminarMarca(Marca marca);
    }
}
