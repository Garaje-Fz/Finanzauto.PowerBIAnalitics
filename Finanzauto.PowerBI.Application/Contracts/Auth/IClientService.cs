using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Contracts.Auth
{
    public interface IClientService
    {
        Task<bool> ValidateApiKey(string apiKey, string domain, string ip);
        Task<Dictionary<string, Guid>> GetActiveClients();
        Task InvalidateApiKey(string apiKey);
    }
}
