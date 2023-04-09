namespace TecnoShop.Models
{
    public interface IMarcaRepositorio
    {
        IEnumerable<Marca> TodasLasMarcas { get; }

        void CrearMarca(Marca marca);

        //void ActualizarMarca(Marca marca);

        //void EliminarMarca(Marca marca);
    }
}
