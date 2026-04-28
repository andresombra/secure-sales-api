using SecureSales.Application.DTOs;
using SecureSales.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureSales.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> Listar();
    }
}
