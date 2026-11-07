using DevXuongMoc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevXuongMoc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AspNetUserController : Controller
    {
        private readonly IAspNetUserService _aspNetUserService;
        public AspNetUserController(IAspNetUserService aspNetUserService)
        {
            _aspNetUserService = aspNetUserService;
        }
        /// <summary>
        /// lấy tất cả danh sách người dùng
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index(string? q)
        {
            var model = await _aspNetUserService.GetAllAsync(q);    
            ViewBag.Query = q;
            return View(model);                          
        }
    }
}
