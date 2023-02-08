using Microsoft.AspNetCore.Mvc;
using QuanLyCaSi.Models;

namespace QuanLyCaSi.Controllers
{
    public class BaiHatController : Controller
    {
        public IActionResult LietKeBaiHat()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(QuanLyCaSi.Models.StoreContext)) as StoreContext;
            return View(context.getBaiHats());
        }

        public IActionResult DeleteBaiHat(BaiHat bh)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(QuanLyCaSi.Models.StoreContext)) as StoreContext;
            int count = context.DeleteBaiHat(bh.MaBaiHat);
            if (count > 0)
                ViewData["thongbao"] = "Delete bai hat thanh cong";
            else
                ViewData["thongbao"] = "Delete bai hat khong thanh cong";
            return View();
        }

        public IActionResult TimBaiHatTheoTen()
        {
            return View();
        }

        public IActionResult TimBaiHat(BaiHat bh)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(QuanLyCaSi.Models.StoreContext)) as StoreContext;
            int count = context.TimBaiHatTheoTen(bh.TenBaiHat);
            if(count > 0)
                ViewData["thongbao"] = "Tim thay";
            else
                ViewData["thongbao"] = "Khong tim thay";
            return View();
        }

        public IActionResult LietKeNBaiHat()
        {
            return View();
        }
        public IActionResult LietKeCacBaiHat(int num)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(QuanLyCaSi.Models.StoreContext)) as StoreContext;
            return View(context.LietKeNBaiHat(num));
        }

        public IActionResult LietKeCacBaiHatCoTrongAlbum(Album al)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(QuanLyCaSi.Models.StoreContext)) as StoreContext;
            return View(context.LietKeCacBaiHatCoTrongAlbum(al.MaAlbum));
        }
    }
}
