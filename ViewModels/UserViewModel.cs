namespace RealState.Web.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public DateTime? InactiveDate { get; set; }
        public int CreationUserId { get; set; }
    }
}
