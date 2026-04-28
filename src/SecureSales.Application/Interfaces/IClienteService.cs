using SecureSales.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureSales.Application.Interfaces
{
    public interface IClienteService
    {
        Guid Criar(ClienteDto dto);
    }
}
