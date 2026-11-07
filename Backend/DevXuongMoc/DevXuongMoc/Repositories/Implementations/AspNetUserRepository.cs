using DevXuongMoc.Data;
using DevXuongMoc.Models.DBModel;
using DevXuongMoc.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DevXuongMoc.Repositories.Implementations
{
    public class AspNetUserRepository : IAspNetUserRepository
    {
        private readonly XuongMocContext _xuongMocContext;
        public AspNetUserRepository(XuongMocContext xuongMocContext)
        {
            _xuongMocContext = xuongMocContext;
        }
        /// <summary>
        /// lấy tất cả danh sách hoặc theo key truyền vào
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<AspNetUser>> GetAllAsync(string? keyword)
        {
            var user = _xuongMocContext.AspNetUsers
           .Include(x => x.Roles)
           .AsNoTracking()
           .AsQueryable();
            // nếu có key
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                user = user.Where(x => x.UserName.Contains(keyword) || (x.Email != null && x.Email.Contains(keyword)));
            }
            var result = await user.OrderBy(x => x.FullName).ToListAsync();
            return result;
        }
    }
}
