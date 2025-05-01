using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using FinBridge.App.Services;
using FinBridge.Data;
using FinBridge.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;

namespace FinBridge.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder
                .Services
                .AddDbContext<FinBridgeContext>(options =>
                options.UseSqlServer("Server =.; Database=FinBridge;Integrated Security = True; TrustServerCertificate=True"));

            builder
                .Services
                .AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<FinBridgeContext>()
                .AddDefaultTokenProviders();

            builder
                .Services
                .AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            builder
                .Services
                .AddAuthorizationCore();


            builder.Services
                .AddMauiBlazorWebView();
            builder.Services
                .AddScoped<IAuthenticationService, AuthenticationService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
