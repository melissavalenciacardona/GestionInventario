namespace LabSoft.Data.Repositorio
{
    public interface IDireccionRepository
    {
        List<Direccion> GetDireccion();
        Direccion? GetDireccionById(string id);
        void AddDireccion(Direccion direcion);
    }
}