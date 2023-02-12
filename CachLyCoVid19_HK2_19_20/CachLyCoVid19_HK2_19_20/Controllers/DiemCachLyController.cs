using CachLyCoVid19_HK2_19_20.Models;
using Microsoft.AspNetCore.Mvc;

namespace CachLyCoVid19_HK2_19_20.Controllers
{
    public class DiemCachLyController : Controller
    {
        public IActionResult Cau1()
        {
            return View();
        }
        public IActionResult ThemDiemCachLy(DiemCachLy dcl)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(CachLyCoVid19_HK2_19_20.Models.StoreContext)) as StoreContext;
            context.ThemDiemCachLy(dcl);
            return View("Cau1");
        }
        public IActionResult Cau3()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(CachLyCoVid19_HK2_19_20.Models.StoreContext)) as StoreContext;
            return View(context.LietKeDiemCachLy());
        }
    }
}
