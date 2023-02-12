using Microsoft.AspNetCore.Mvc;
using PlayList_HK1_2122.Models;

namespace PlayList_HK1_2122.Controllers
{
    public class BaiHatController : Controller
    {
        public IActionResult Cau1()
        {
            return View();
        }
        public IActionResult ThemBaiHat(BaiHat bh)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PlayList_HK1_2122.Models.StoreContext)) as StoreContext;
            context.ThemBaiHat(bh);
            return View("Cau1");
        }
    }
}
