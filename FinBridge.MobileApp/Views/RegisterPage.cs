using FinBridge.MobileApp.Models;
using FinBridge.MobileApp.Services;

namespace FinBridge.MobileApp.Views
{
    public partial class RegisterPage : ContentPage
    {
        private readonly IAuthenticationService _authService;

        public RegisterPage(IAuthenticationService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            var registerRequest = new RegisterRequest
            {
                FirstName = FirstNameEntry.Text,
                LastName = LastNameEntry.Text,
                Username = UsernameEntry.Text,
                Email = EmailEntry.Text,
                Password = PasswordEntry.Text
            };

            var result = await _authService.RegisterAsync(registerRequest);

            if (result.IsSuccess)
            {
                // Navigate to the sign-in page or show success message
                await DisplayAlert("Success", "Registration successful", "OK");
                await Navigation.PushAsync(new LoginPage(_authService)); // Navigate to login page
            }
            else
            {
                // Show error message
                ErrorLabel.Text = result.ErrorMessage;
                ErrorLabel.IsVisible = true;
            }
        }
    }
}
