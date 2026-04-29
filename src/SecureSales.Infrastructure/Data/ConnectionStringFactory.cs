using Microsoft.Extensions.Configuration;
using SecureSales.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureSales.Infrastructure.Data
{
    public class ConnectionStringFactory : IConnectionStringFactory
    {
        private readonly ISecretProvider _secretProvider;
        private readonly IConfiguration _configuration;

        public ConnectionStringFactory(ISecretProvider secretProvider, IConfiguration configuration)
        {
            _secretProvider = secretProvider;
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<string> GetConnectionStringAsync()
        {
            var chaveName = _configuration["KeyVault:ChaveName"];
            return await _secretProvider.GetSecretAsync(chaveName);
        }
    }
}
