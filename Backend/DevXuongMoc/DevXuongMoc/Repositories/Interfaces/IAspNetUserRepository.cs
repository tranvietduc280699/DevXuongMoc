using DevXuongMoc.Models.DBModel;

namespace DevXuongMoc.Repositories.Interfaces
{
    public interface IAspNetUserRepository
    {
        public Task<List<AspNetUser>> GetAllAsync(string? keyword);
    }
}
