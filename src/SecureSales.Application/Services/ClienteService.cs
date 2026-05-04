using MapsterMapper;
using SecureSales.Application.DTOs;
using SecureSales.Application.Interfaces;
using SecureSales.Domain.Entities;
using SecureSales.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureSales.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDto>> Listar()
        {
            var listaCliente = await _clienteRepository.ListarAsync();

            var listaClienteDto = _mapper.Map<IEnumerable<ClienteDto>>(listaCliente);

            return listaClienteDto;
        }

        public async Task<ClienteDto> Incluir(ClienteDto clienteDto)
        {
            var cliente = _mapper.Map<Cliente>(clienteDto);
            var clienteIncluido = await _clienteRepository.IncluirAsync(cliente);
            return _mapper.Map<ClienteDto>(clienteIncluido);
        }

        public async Task<ClienteDto> Editar(ClienteDto clienteDto)
        {
            var cliente = _mapper.Map<Cliente>(clienteDto);
            var clienteEditado = await _clienteRepository.EditarAsync(cliente);
            return _mapper.Map<ClienteDto>(clienteEditado);
        }
    }
}
