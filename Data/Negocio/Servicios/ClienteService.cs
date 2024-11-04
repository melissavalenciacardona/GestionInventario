
using LabSoft.Data.Repositorio;

namespace LabSoft.Data.Negocio.Servicios {
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository){
            this._clienteRepository = clienteRepository;
        }

        public void AddCliente(Cliente cliente)
        {
            cliente.Id = Guid.NewGuid().ToString();
            cliente.Estado = "1";
            cliente.FechaRegistro = DateTime.Now;
            
            _clienteRepository.AddCliente(cliente);
        }

        public void DeleteCliente(string id)
        {
            _clienteRepository.DeleteCliente(id);
        }

        public Cliente? GetClienteById(string id)
        {
            return _clienteRepository.GetClienteById(id);
        }

        public List<Cliente> GetClientes()
        {
            return _clienteRepository.GetClientes();
        }

        public void UpdateCliente(Cliente cliente)
        {
            var clienteUpd = _clienteRepository.GetClienteById(cliente.Id);
            
            if(clienteUpd != null){
                clienteUpd.Nombre = cliente.Nombre;
                clienteUpd.Email = cliente.Email;
                clienteUpd.Telefono = cliente.Telefono;

                _clienteRepository.UpdateCliente(clienteUpd);
            }
            
        }
    }
}