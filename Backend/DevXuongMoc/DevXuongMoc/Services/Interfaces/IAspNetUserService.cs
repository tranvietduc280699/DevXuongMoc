using DevXuongMoc.ViewModels;

namespace DevXuongMoc.Services.Interfaces
{
    public interface IAspNetUserService
    {
        Task<List<AspNetUserListItemVM>> GetAllAsync(string? keyword);
    }
}
