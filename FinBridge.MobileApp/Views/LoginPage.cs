using FinBridge.MobileApp.Models;
using FinBridge.MobileApp.Services;

namespace FinBridge.MobileApp.Views
{
    public partial class LoginPage : ContentPage
    {
        private readonly IAuthenticationService _authService;

        public LoginPage(IAuthenticationService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private async void OnSignInClicked(object sender, EventArgs e)
        {
            var username = UsernameEntry.Text;
            var password = PasswordEntry.Text;

            // Call your authentication service
            var loginSuccess = await _authService.LoginAsync(username, password);

            if (loginSuccess)
            {
                // Navigate to the next page, e.g., HomePage
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                // Show error message
                ErrorLabel.IsVisible = true;
                ErrorLabel.Text = "Invalid username or password";
            }
        }

        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }

}
