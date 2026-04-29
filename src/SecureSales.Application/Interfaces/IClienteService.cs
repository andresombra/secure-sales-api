using SecureSales.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureSales.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> Listar();
    }
}
