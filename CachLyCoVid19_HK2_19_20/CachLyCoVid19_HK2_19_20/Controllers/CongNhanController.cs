using CachLyCoVid19_HK2_19_20.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CachLyCoVid19_HK2_19_20.Controllers
{
    public class CongNhanController : Controller
    {
        public IActionResult Cau2()
        {
            return View();
        }
        public IActionResult LietKeCongNhanCoTuNTrieuChung(int num) {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(CachLyCoVid19_HK2_19_20.Models.StoreContext)) as StoreContext;
            return View(context.LietKeCongNhanCoTuNTrieuChung(num));
        }
        public IActionResult LietKeCongNhanTrongDiemCachLy(DiemCachLy dcl)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(CachLyCoVid19_HK2_19_20.Models.StoreContext)) as StoreContext;
            return View(context.LietKeCongNhanTrongDiemCachLy(dcl));
        }

        public void XoaCongNhan(string MaCongNhan)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(CachLyCoVid19_HK2_19_20.Models.StoreContext)) as StoreContext;
            context.XoaCongNhan(MaCongNhan);
        }

        public IActionResult ViewCongNhan(string MaCongNhan)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(CachLyCoVid19_HK2_19_20.Models.StoreContext)) as StoreContext;
            ViewData.Model = context.ViewCongNhan(MaCongNhan);
            return View();
        }
    }
}
