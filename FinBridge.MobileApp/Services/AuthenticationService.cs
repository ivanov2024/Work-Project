using FinBridge.MobileApp.Models;
using Microsoft.EntityFrameworkCore;
using FinBridge.Data;
using FinBridge.Data.Models;

namespace FinBridge.MobileApp.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly FinBridgeContext _dbContext;

        public AuthenticationService(FinBridgeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AuthenticationResult> SignInAsync(LoginRequest request)
        {
            var user = await _dbContext.Users
                .Include(u => u.CustomerProfile)
                .FirstOrDefaultAsync(u => u.UserName == request.Username || u.Email == request.Username);

            if (user == null)
            {
                return new AuthenticationResult { IsSuccess = false, ErrorMessage = "Invalid credentials" };
            }

            var isPasswordValid = user.PasswordHash == request.Password; // You should hash and verify password in real applications

            if (!isPasswordValid)
            {
                return new AuthenticationResult { IsSuccess = false, ErrorMessage = "Invalid credentials" };
            }

            return new AuthenticationResult { IsSuccess = true };
        }

        public async Task<AuthenticationResult> RegisterAsync(RegisterRequest request)
        {
            var existingUser = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.UserName == request.Username || u.Email == request.Email);

            if (existingUser != null)
            {
                return new AuthenticationResult { IsSuccess = false, ErrorMessage = "User already exists" };
            }

            var user = new ApplicationUser
            {
                UserName = request.Username,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PasswordHash = request.Password
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return new AuthenticationResult { IsSuccess = true };
        }
    }
}
