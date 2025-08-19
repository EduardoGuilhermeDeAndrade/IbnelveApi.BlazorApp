using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace IbnelveApi.BlazorApp.Services
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal _currentUser = new ClaimsPrincipal(new ClaimsIdentity());

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(_currentUser));
        }

        public void MarkUserAsAuthenticated(string email, string tenantId)
        {
            var identity = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, email),
            new Claim(ClaimTypes.Email, email),
            new Claim("TenantId", tenantId)
        }, "apiauth");

            _currentUser = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public void MarkUserAsLoggedOut()
        {
            // CRÍTICO: Limpar completamente o estado
            _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
