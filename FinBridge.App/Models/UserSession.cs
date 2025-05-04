namespace FinBridge.App.Models
{
    public class UserSession
    {
        public string Username { get; set; } 
            = null!;
        public string Role { get; set; } 
            = null!;
        public bool RememberMe { get; set; }
    }
}
