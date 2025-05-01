using FinBridge.App.Models;
using FinBridge.Data;
using FinBridge.Data.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

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
            var dbContext = scope.ServiceProvider.GetRequiredService<FinBridgeContext>();

            var user = new ApplicationUser
            {
                UserName = model.FirstName + model.LastName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return false;

            var customer = new Customer
            {
                ApplicationUserId = user.Id
            };

            await dbContext.Customers.AddAsync(customer);
            await dbContext.SaveChangesAsync();

            await SaveUserSessionAsync(user, userManager, scope);
            return true;
        }

        public async Task<bool> SignInAsync(LoginRequest model)
        {
            using var scope = _serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return false;

            var isValidPassword = await userManager.CheckPasswordAsync(user, model.Password);
            if (!isValidPassword)
                return false;

            await SaveUserSessionAsync(user, userManager, scope);
            return true;
        }

        /// <summary>
        /// Persists user session to secure storage and notifies authentication state provider.
        /// </summary>
        private static async Task SaveUserSessionAsync(ApplicationUser user, UserManager<ApplicationUser> userManager, IServiceScope scope)
        {
            var role = (await userManager.GetRolesAsync(user)).FirstOrDefault() ?? "User";

            var userSession = new UserSession
            {
                Username = user.UserName!,
                Role = role
            };

            var sessionJson = JsonSerializer.Serialize(userSession);
            await SecureStorage.SetAsync("user_session", sessionJson);

            var authProvider = scope.ServiceProvider.GetRequiredService<AuthenticationStateProvider>() as CustomAuthStateProvider;
            authProvider?.SetUser(user.UserName!);
        }

        public async Task SignOutAsync()
        {
            using var scope = _serviceProvider.CreateScope();
            var signInManager = scope.ServiceProvider.GetRequiredService<SignInManager<ApplicationUser>>();
            await signInManager.SignOutAsync();
        }
    }
}
