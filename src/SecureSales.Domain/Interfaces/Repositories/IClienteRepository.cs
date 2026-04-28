using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecureSales.Domain.Interfaces.Repositories;
using SecureSales.Domain;

namespace SecureSales.Domain.Interfaces.Repositories
{
    public interface IClienteRepository 
    {
        Task<IEnumerable<Cliente>> ListarAsync();
    }
}
