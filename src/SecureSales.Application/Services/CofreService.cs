using Azure.Security.KeyVault.Secrets;
using SecureSales.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SecureSales.Application.Services
{
    public sealed class CofreService : ICofreService
    {
        private readonly SecretClient _secretClient;

        public CofreService(SecretClient secretClient)
        {
            _secretClient = secretClient ?? throw new ArgumentNullException(nameof(secretClient));
        }

        public async Task<string> ObterSegredoAsync(string nomeSegredo, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(nomeSegredo))
                throw new ArgumentException("O nome do segredo é obrigatório.", nameof(nomeSegredo));

            var secret = await _secretClient.GetSecretAsync(nomeSegredo, cancellationToken: cancellationToken);
            return secret.Value.Value ?? string.Empty;
        }
    }
}