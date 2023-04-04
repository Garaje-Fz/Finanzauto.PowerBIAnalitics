using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Contracts.Auth
{
    public interface ICacheService
    {
        ValueTask<string?> GetOwnerIdFromApiKey(string apiKey, string domain, string ip);
        Task InvalidateApiKey(string apiKey);
    }
}
