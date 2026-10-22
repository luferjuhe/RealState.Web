namespace RealState.Web.ViewModels
{
    public class LoginViewModel
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ReturnUrl { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
