using Microsoft.AspNetCore.Mvc;

namespace DevXuongMoc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        /// <summary>
        /// trang chính khi đăng nhập
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
