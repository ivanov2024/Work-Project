using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace FinBridge.App.Services
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ClaimsPrincipal _anonymous 
            = new ClaimsPrincipal(new ClaimsIdentity());

        private string? _userName;

        public void SetUser(string userName)
        {
            _userName = userName;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public void ClearUser()
        {
            _userName = null;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (string.IsNullOrEmpty(_userName))
            {
                return Task.FromResult(new AuthenticationState(_anonymous));
            }

            var identity = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, _userName),
        }, "Custom authentication");

            var user = new ClaimsPrincipal(identity);
            return Task.FromResult(new AuthenticationState(user));
        }
    }
}
