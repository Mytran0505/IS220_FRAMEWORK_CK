using Microsoft.AspNetCore.Mvc;
using PlayList_HK1_2122.Models;

namespace PlayList_HK1_2122.Controllers
{
    public class PlayListController : Controller
    {
        public IActionResult LietKePLCuaNguoiNghe(NguoiNghe nn)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PlayList_HK1_2122.Models.StoreContext)) as StoreContext;
            return View(context.LietKePLCuaNguoiNghe(nn));
        }
        public void XoaPLayPlist(string MaPlayList)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PlayList_HK1_2122.Models.StoreContext)) as StoreContext;
            context.XoaPLayPlist(MaPlayList);
        }
        public IActionResult ViewThongTinPlayList(string MaPlayList)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PlayList_HK1_2122.Models.StoreContext)) as StoreContext;
            return View(context.ViewThongTinPlayList(MaPlayList));
        }
    }
}
