using SecureSales.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureSales.Domain.Interfaces.Repositories
{
    public interface IClienteRepository 
    {
        Task<IEnumerable<Cliente>> ListarAsync();
        Task<Cliente> IncluirAsync(Cliente cliente);
        Task<Cliente> EditarAsync(Cliente cliente);
    }
}
