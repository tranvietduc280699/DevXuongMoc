namespace AdminShop.ViewModels
{
    public class UserListItemVM
    {
        public string Id { get; set; } = "";
        public string FullName { get; set; } = "";
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string Roles { get; set; } = "";
        public bool IsActive { get; set; }
        public bool EmailConfirmed { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public int AccessFailedCount { get; set; }
    }
}
