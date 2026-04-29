using System.Threading.Tasks;

namespace SecureSales.Application.Interfaces
{
    public interface IConnectionStringFactory
    {
        Task<string> GetConnectionStringAsync();
    }
}
