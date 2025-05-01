using FinBridge.App.Models;

namespace FinBridge.App.Services
{
    public interface IAuthenticationService
    {
        Task<bool> SignInAsync(LoginRequest model);
        Task<bool> RegisterAsync(RegisterRequest model);
        Task SignOutAsync();
    }
}
