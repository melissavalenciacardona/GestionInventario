
namespace LabSoft.Data.Repositorio
{
    public class ClienteRepository : IClienteRepository
    {
        private static readonly List<Cliente> clientes = new List<Cliente>();

        static ClienteRepository()
        {
            for (int i = 0; i < 5; i++)
            {
                var nombre = DataGenerator.GenerateRandomName();
                clientes.Add(new Cliente
                {
                    Id = i.ToString(),
                    Nombre = nombre,
                    Apellido = DataGenerator.GenerateRandomLastName(),
                    TipoDocumento = DataGenerator.GenerateRandomDNIType(),
                    NumeroDocumento = DataGenerator.GenerateRandomDNI(),
                    Email = DataGenerator.GenerateRandomEmail(nombre),
                    Telefono = DataGenerator.GenerateRandomPhone(),
                    Direccion = DataGenerator.GenerateRandomAddress(),
                    FechaRegistro = DateTime.UtcNow.AddDays(-1),
                    Estado = "Activo",
                    Preferencia = DataGenerator.GenerateRandomPreferences(),
                    Password = DataGenerator.GenerateRandomPassword()
                });
            }
        }

        public void AddCliente(Cliente cliente)
        {
            clientes.Add(cliente);
        }

        public void DeleteCliente(string id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                clientes.Remove(cliente);
            }
        }

        public Cliente? GetClienteById(string id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            return cliente;
        }

        public Cliente? GetClienteByEmail(string Email)
        {
            var cliente = clientes.FirstOrDefault(c => c.Email == Email);
            return cliente;
        }

        public List<Cliente> GetClientes()
        {
            return clientes;
        }

        public void UpdateCliente(Cliente cliente)
        {
            var indice = clientes.FindIndex(c => c.Id.Equals(cliente.Id));
            if (indice > -1)
            {
                clientes[indice] = cliente;
            }

        }

        public void UpdateClienteState(string id, string state)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null && cliente.Estado != state && (state == "Activo" || state == "Inactivo"))
            {
                cliente.Estado = state;
            }
        }
    }
}