namespace LabSoft.Data.Negocio.Servicios
{
    public interface IClienteService {
        List<Cliente> GetClientes();
        Cliente? GetClienteById(string id);
        Cliente? GetClienteByEmail(string Email);
        void AddCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        void DeleteCliente(string id);
        void UpdateClienteState(string id, string state);
        bool ValidateCliente(string email, string password);
    }
}