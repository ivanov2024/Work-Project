using FinBridge.App.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;

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

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var sessionJson = await SecureStorage.GetAsync("user_session");

                if (string.IsNullOrWhiteSpace(sessionJson))
                {
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                }

                var session = JsonSerializer.Deserialize<UserSession>(sessionJson);
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, session.Username),
                    new Claim(ClaimTypes.Role, session.Role),
                }, "custom");

                return new AuthenticationState(new ClaimsPrincipal(identity));
            }
            catch
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }

        public void MarkUserAsLoggedOut()
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymousUser)));
        }
    }
}
