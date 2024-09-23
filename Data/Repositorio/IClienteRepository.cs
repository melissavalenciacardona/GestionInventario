namespace LabSoft.Data.Repositorio
{
    public interface IClienteRepository {
        List<Cliente> GetClientes();
        Cliente? GetClienteById(string id);
        void AddCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        void DeleteCliente(string id);
    }
}