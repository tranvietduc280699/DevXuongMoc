namespace DevXuongMoc.ViewModels
{
    public class AspNetUserListItemVM
    {
        public string Id { get; set; } = "";
        public string FullName { get; set; } = "";
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string Roles { get; set; } = "";
        public bool IsActive { get; set; }
        public bool EmailConfirmed { get; set; }
        // khóa khi nhập sai nhiều lần
        public DateTimeOffset? LockoutEnd { get; set; }
        // số lần nhập sai
        public int AccessFailedCount { get; set; }
    }
}
