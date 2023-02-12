using Microsoft.AspNetCore.Mvc;
using PlayList_HK1_2122.Models;

namespace PlayList_HK1_2122.Controllers
{
    public class NguoiNgheController : Controller
    {
        public IActionResult Cau3()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PlayList_HK1_2122.Models.StoreContext)) as StoreContext;
            return View(context.LietKeTenNguoiNghe());
        }


    }
}
