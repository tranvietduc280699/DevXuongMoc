using DevXuongMoc.Repositories.Interfaces;
using DevXuongMoc.Services.Interfaces;
using DevXuongMoc.ViewModels;

namespace DevXuongMoc.Services.Implementations
{
    public class AspNetUserService : IAspNetUserService
    {
        private readonly IAspNetUserRepository _aspNetUserRepository;
        public AspNetUserService(IAspNetUserRepository aspNetUserRepository)
        {
            _aspNetUserRepository = aspNetUserRepository;
        }
        /// <summary>
        /// lấy tất cả user, nếu có key thì lấy theo key
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<List<AspNetUserListItemVM>> GetAllAsync(string? keyword)
        {
            var users = await _aspNetUserRepository.GetAllAsync(keyword);
            var userList = new List<AspNetUserListItemVM>();
            foreach (var x in users)
            {
                userList.Add(new AspNetUserListItemVM
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    Email = x.Email,
                    UserName = x.UserName,
                    PhoneNumber = x.PhoneNumber,
                    Roles = string.Join(", ", x.Roles.Select(r => r.Name)),
                    IsActive = x.IsActive,
                    EmailConfirmed = x.EmailConfirmed,
                    LockoutEnd = x.LockoutEnd,
                    AccessFailedCount = x.AccessFailedCount
                });
            }
            return userList;
        }
    }
}
