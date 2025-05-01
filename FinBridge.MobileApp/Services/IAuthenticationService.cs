using FinBridge.MobileApp.Models;

namespace FinBridge.MobileApp.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> SignInAsync(LoginRequest request);
        Task<AuthenticationResult> RegisterAsync(RegisterRequest request);
    }
}
