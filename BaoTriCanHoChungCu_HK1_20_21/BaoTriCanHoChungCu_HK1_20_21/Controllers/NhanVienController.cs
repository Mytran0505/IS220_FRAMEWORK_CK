using BaoTriCanHoChungCu_HK1_20_21.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaoTriCanHoChungCu_HK1_20_21.Controllers
{
    public class NhanVienController : Controller
    {
        public IActionResult LietKeNhanVienCoNLanSua()
        {
            return View();
        }

        public IActionResult CacNhanVienCoNLanSua(int num)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(BaoTriCanHoChungCu_HK1_20_21.Models.StoreContext)) as StoreContext;
            return View(context.CacNhanVienCoNLanSua(num));
        }

        public IActionResult LietKeNhanVien()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(BaoTriCanHoChungCu_HK1_20_21.Models.StoreContext)) as StoreContext;
            return View(context.LietKeNhanVien());
        }
    }
}
