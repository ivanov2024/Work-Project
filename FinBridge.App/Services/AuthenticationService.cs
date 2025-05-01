using FinBridge.App.Models;
using FinBridge.Data.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FinBridge.App.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IServiceProvider _serviceProvider;

        public AuthenticationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<bool> RegisterAsync(RegisterRequest model)
        {
            using var scope = _serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var user = new ApplicationUser
            {
                UserName = model.FirstName + " " + model.LastName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
            };

            var Customer = new Customer
            {

            };

            var result = await userManager.CreateAsync(user, model.Password);
            return result.Succeeded;
        }

        public async Task<bool> SignInAsync(LoginRequest model)
        {
            using var scope = _serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var authProvider = scope.ServiceProvider.GetRequiredService<AuthenticationStateProvider>() as CustomAuthStateProvider;

            // Find user by email
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return false;

            // Check if password is valid
            var isValidPassword = await userManager.CheckPasswordAsync(user, model.Password);
            if (!isValidPassword)
                return false;

            // Build session info
            var userSession = new UserSession
            {
                Username = user.UserName!,
                Role = (await userManager.GetRolesAsync(user)).FirstOrDefault() ?? "User"
            };

            // Notify custom provider
            authProvider?.SetUser(userSession.Username);

            return true;
        }

        public async Task SignOutAsync()
        {
            using var scope = _serviceProvider.CreateScope();
            var signInManager = scope.ServiceProvider.GetRequiredService<SignInManager<ApplicationUser>>();
            await signInManager.SignOutAsync();
        }
    }
}
