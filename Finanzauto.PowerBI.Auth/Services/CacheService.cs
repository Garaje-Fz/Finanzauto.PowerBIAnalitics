using Finanzauto.PowerBI.Application.Contracts.Auth;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Auth.Services
{
    public class CacheService : ICacheService
    {
        private static readonly TimeSpan _cacheKeysTimeToLive = new(1, 0, 0);

        private readonly IMemoryCache _memoryCache;
        private readonly IClientService _clientsService;

        public CacheService(IMemoryCache memoryCache, IClientService clientsService)
        {
            _memoryCache = memoryCache;
            _clientsService = clientsService;
        }

        public async ValueTask<string?> GetOwnerIdFromApiKey(string apiKey, string domain, string ip)
        {
            if (!_memoryCache.TryGetValue<Dictionary<string, Guid>>("Authentication_ApiKeys", out var internalKeys))
            {
                var isValidApiKey = await _clientsService.ValidateApiKey(apiKey, domain, ip);
                if (!isValidApiKey)
                    return null;

                internalKeys = await _clientsService.GetActiveClients();

                _memoryCache.Set("Authentication_ApiKeys", internalKeys, _cacheKeysTimeToLive);
            }

            if (!internalKeys.TryGetValue(apiKey, out var clientId))
            {
                return null;
            }

            return clientId.ToString();
        }

        public async Task InvalidateApiKey(string apiKey)
        {
            if (_memoryCache.TryGetValue<Dictionary<string, Guid>>("Authentication_ApiKeys", out var internalKeys))
            {
                if (internalKeys.ContainsKey(apiKey))
                {
                    internalKeys.Remove(apiKey);
                    _memoryCache.Set("Authentication_ApiKeys", internalKeys);
                }
            }

            await _clientsService.InvalidateApiKey(apiKey);
        }
    }
}
