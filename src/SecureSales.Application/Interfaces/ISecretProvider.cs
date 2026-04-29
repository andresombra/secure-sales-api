using System.Threading.Tasks;

namespace SecureSales.Application.Interfaces
{
    public interface ISecretProvider
    {
        Task<string> GetSecretAsync(string secretName);
    }
}
