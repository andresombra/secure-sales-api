using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureSales.Application.Interfaces
{
    public interface ISecretProvider
    {
        Task<string> GetSecretAsync(string secretName);
    }
}
