using BaoTriCanHoChungCu_HK1_20_21.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaoTriCanHoChungCu_HK1_20_21.Controllers
{
    public class NV_BTController : Controller
    {
        public IActionResult LietKeChiTietThietBiNhanVienDaSua(string MaNhanVien)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(BaoTriCanHoChungCu_HK1_20_21.Models.StoreContext)) as StoreContext;
            return View(context.LietKeChiTietThietBiNhanVienDaSua(MaNhanVien));
        }
        public void XoaChiTietSuaThietbiCuaNhanVien(string MaNhanVien, string MaThietBi)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(BaoTriCanHoChungCu_HK1_20_21.Models.StoreContext)) as StoreContext;
            context.XoaChiTietSuaThietbiCuaNhanVien(MaNhanVien, MaThietBi);
        }

        public IActionResult ViewChiTietThietBi(string MaNhanVien, string MaThietBi, string MaCanHo, int LanThu)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(BaoTriCanHoChungCu_HK1_20_21.Models.StoreContext)) as StoreContext;
            ViewData.Model = context.ViewChiTietThietBi(MaNhanVien, MaThietBi, MaCanHo, LanThu);
            return View();
        }

        public void UpdateNV_BT(NV_BT bt, string MaNV, string MaTB, string MaCH, int LT)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(BaoTriCanHoChungCu_HK1_20_21.Models.StoreContext)) as StoreContext;
            context.UpdateNV_BT(bt, MaNV, MaTB, MaCH,LT);
        }
    }
}
