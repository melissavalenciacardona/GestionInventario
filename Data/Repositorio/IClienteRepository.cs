namespace LabSoft.Data.Repositorio
{
    public interface IClienteRepository {
        List<Cliente> GetClientes();
        Cliente? GetClienteById(string id);
        Cliente? GetClienteByEmail(string Email);
        void AddCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        void DeleteCliente(string id);
        void UpdateClienteState(string id, string state);
    }
}