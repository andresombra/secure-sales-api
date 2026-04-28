using SecureSales.Application.DTOs;
using SecureSales.Application.Interfaces;
using SecureSales.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureSales.Application.Services
{
    public class ClienteService : IClienteService
    {
        public Guid Criar(ClienteDto dto)
        {
            var cliente = new Cliente
            {
                Nome = dto.Nome
            };

            return cliente.Id;
        }
    }
}
