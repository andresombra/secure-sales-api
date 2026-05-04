using SecureSales.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureSales.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDto>> Listar();
        Task<ClienteDto> Incluir(ClienteDto clienteDto);
        Task<ClienteDto> Editar(ClienteDto clienteDto);
    }
}
