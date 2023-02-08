using Microsoft.AspNetCore.Mvc;
using QuanLyCaSi.Models;
namespace QuanLyCaSi.Controllers
{
    public class CaSiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LietKeCaSi()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(QuanLyCaSi.Models.StoreContext)) as StoreContext;
            return View(context.GetCaSis());
        }

        public IActionResult XoaCaSi(string id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(QuanLyCaSi.Models.StoreContext)) as StoreContext;
            int count = context.XoaCaSi(id);
            if(count > 0)
                ViewData["thongbao"] = "Xoa thanh cong";
            else
                ViewData["thongbao"] = "Xoa khong thanh cong";
            return View();
        }
        public IActionResult ViewCaSi(string id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(QuanLyCaSi.Models.StoreContext)) as StoreContext;
            CaSi cs = context.ViewCaSi(id);
            ViewData.Model = cs;
            return View();
        }
        public IActionResult UpdateCaSi(CaSi cs)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(QuanLyCaSi.Models.StoreContext)) as StoreContext;
            int count = context.UpdateCaSi(cs);
            if (count > 0)
                ViewData["thongbao"] = "Update thanh cong";
            else
                ViewData["thongbao"] = "Update khong thanh cong";
            return View();
        }

        public IActionResult InsertCaSi (CaSi cs)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(QuanLyCaSi.Models.StoreContext)) as StoreContext;
            int count = context.InsertCaSi(cs);
            if (count > 0)
                ViewData["thongbao"] = "Insert thanh cong";
            else
                ViewData["thongbao"] = "Insert khong thanh cong";
            return View();
        }

        public IActionResult EnterCaSi()
        {
            return View();
        }
    }
}
