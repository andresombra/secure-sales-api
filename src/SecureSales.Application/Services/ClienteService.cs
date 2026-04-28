using SecureSales.Application.DTOs;
using SecureSales.Application.Interfaces;
using SecureSales.Domain;
using SecureSales.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureSales.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> Listar()
        {
            return await _clienteRepository.ListarAsync();
        }
    }
}
