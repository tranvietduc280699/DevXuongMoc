using AdminShop.ViewModels;
using DevXuongMoc.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevXuongMoc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AspNetUserController : Controller
    {
        private readonly XuongMocContext _context;
        public AspNetUserController(XuongMocContext context)
        {
            _context= context;
        }
        /// <summary>
        /// lấy tất cả user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _context.AspNetUsers 
                .AsNoTracking()
                .OrderBy(x => x.FullName)
                .Select(x => new UserListItemVM
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
                })
                .ToListAsync();

            return View(users);
        }
    }
}
