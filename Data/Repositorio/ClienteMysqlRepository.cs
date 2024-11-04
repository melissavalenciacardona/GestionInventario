
using Microsoft.EntityFrameworkCore;

namespace LabSoft.Data.Repositorio
{
    public class ClienteMysqlRepository : IClienteRepository
    {
        private readonly MyDbContext _context; //Todos los resposiotrios deben tener un contexto

        public ClienteMysqlRepository(MyDbContext context) //Inyectando dependencia de la BD
        {
            _context = context;
        }
        public void AddCliente(Cliente cliente)
        {
            var result = _context.Cliente.Add(cliente);
            _context.SaveChanges();
        }
        public void DeleteCliente(string id)
        {
            var cliente = _context.Cliente.FirstOrDefault(clienteId => clienteId.Id.Equals(id));

            if(cliente != null){
                _context.Cliente.Remove(cliente);
                _context.SaveChanges();
            }
        }
        public Cliente? GetClienteById(string id)
        {
            var cliente = _context.Cliente
            .Include(direccion => direccion.Direccion)
            .Include(preferencia => preferencia.Preferencia)
            .FirstOrDefault(clienteId => clienteId.Id.Equals(id));
            return cliente;
        }
        public List<Cliente> GetClientes()
        {
            var clientes = _context.Cliente
            .Include(direccion => direccion.Direccion)
            .Include(preferencia => preferencia.Preferencia)
            .ToList();
            return clientes;
        }
        public void UpdateCliente(Cliente cliente)
        {
            var result = _context.Cliente.Update(cliente);
            _context.SaveChanges();
        }
    }
}
