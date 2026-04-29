using System.Threading;
using System.Threading.Tasks;

namespace SecureSales.Application.Interfaces
{
    public interface ICofreService
    {
        Task<string> ObterSegredoAsync(string nomeSegredo, CancellationToken cancellationToken = default);
    }
}