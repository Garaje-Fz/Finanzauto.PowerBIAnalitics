using Finanzauto.PowerBI.Application.Contracts.Auth;
using Finanzauto.PowerBI.Auth.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Auth.Handlers
{
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiKeyAuthenticationOptions>
    {
        private readonly ICacheService _cacheService;

        public ApiKeyAuthenticationHandler(IOptionsMonitor<ApiKeyAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, ICacheService cacheService) : base(options, logger, encoder, clock)
        {
            _cacheService = cacheService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue(ApiKeyAuthenticationOptions.HeaderName, out var apiKey) || apiKey.Count != 1)
            {
                Logger.LogWarning("An API request was received without the x-api-key header");
                return AuthenticateResult.Fail("Invalid parameters");
            }

            string domainName = Request.Host.Value;
            var ip = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

            var clientId = await _cacheService.GetOwnerIdFromApiKey(apiKey, domainName, ip);

            if (clientId == null)
            {
                Logger.LogWarning($"An API request was received with an invalid API key: {apiKey}");
                return AuthenticateResult.Fail("Invalid parameters");
            }

            Logger.BeginScope("{ClientId}", clientId);
            Logger.LogInformation("Client authenticated");

            var claims = new[] { new Claim(ClaimTypes.Name, clientId.ToString()) };
            var identity = new ClaimsIdentity(claims, ApiKeyAuthenticationOptions.DefaultScheme);
            var identities = new List<ClaimsIdentity> { identity };
            var principal = new ClaimsPrincipal(identities);
            var ticket = new AuthenticationTicket(principal, ApiKeyAuthenticationOptions.DefaultScheme);

            return AuthenticateResult.Success(ticket);
        }
    }
}
