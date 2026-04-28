using Microsoft.EntityFrameworkCore;
using SecureSales.Domain;
using SecureSales.Domain.Interfaces.Repositories;
using SecureSales.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureSales.Infrastructure.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Cliente>> ListarAsync()
        {
            return await _context.Set<Cliente>().ToListAsync();
        }
    }
}
