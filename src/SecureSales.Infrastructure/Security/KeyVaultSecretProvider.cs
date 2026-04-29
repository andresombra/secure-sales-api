using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using SecureSales.Application.Interfaces;

namespace SecureSales.Infrastructure.Security
{
    public class KeyVaultSecretProvider : ISecretProvider
    {
        private readonly SecretClient _secretClient;

        public KeyVaultSecretProvider(IConfiguration configuration)
        {
            var keyVaultUrl = configuration["KeyVault:Url"];

            _secretClient = new SecretClient(
                new Uri(keyVaultUrl),
                new DefaultAzureCredential());
        }

        public async Task<string> GetSecretAsync(string secretName)
        {
            var secret = await _secretClient.GetSecretAsync(secretName);
            return secret.Value.Value;
        }
    }
}
