using Microsoft.AspNetCore.Mvc;
using PlayList_HK1_2122.Models;

namespace PlayList_HK1_2122.Controllers
{
    public class CaSiController : Controller
    {
        public IActionResult Cau2()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PlayList_HK1_2122.Models.StoreContext)) as StoreContext;
            return View(context.LietKeNgaySinhCủaCacCaSi());
        }
        public IActionResult LietKeCaSiCoNgaySinhDuocChon(DateTime NamSinh)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PlayList_HK1_2122.Models.StoreContext)) as StoreContext;
            return View(context.LietKeCaSiCoNgaySinhDuocChon(NamSinh));
        }
    }
}
