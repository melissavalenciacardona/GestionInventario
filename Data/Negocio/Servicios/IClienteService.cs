namespace LabSoft.Data.Negocio.Servicios
{
    public interface IClienteService {
        List<Cliente> GetClientes();
        Cliente? GetClienteById(string id);
        void AddCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        void DeleteCliente(string id);
    }
}