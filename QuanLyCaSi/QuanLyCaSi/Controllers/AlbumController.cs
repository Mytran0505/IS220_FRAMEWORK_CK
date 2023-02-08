using Microsoft.AspNetCore.Mvc;
using QuanLyCaSi.Models;
namespace QuanLyCaSi.Controllers
{
    public class AlbumController : Controller
    {
        public IActionResult EnterAlbum()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(QuanLyCaSi.Models.StoreContext)) as StoreContext;
            return View(context.GetCaSis());
        }
        public IActionResult InsertAlbum(Album al)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(QuanLyCaSi.Models.StoreContext)) as StoreContext;
            int count = context.InsertAlbum(al);
            if (count > 0)
                ViewData["thongbao"] = "Insert Album thanh cong";
            else
                ViewData["thongbao"] = "Insert Album khong thanh cong";
            return View();
        }
        public IActionResult AlbumCoNhieuBaiHatNhat() {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(QuanLyCaSi.Models.StoreContext)) as StoreContext;
            return View(context.AlbumCoNhieuBaiHatNhat());  
        }
    }
}
