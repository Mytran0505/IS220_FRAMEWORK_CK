using Microsoft.AspNetCore.Mvc;
using BaoTriCanHoChungCu_HK1_20_21.Models;
namespace BaoTriCanHoChungCu_HK1_20_21.Controllers
{
    public class CanHoController : Controller
    {
        public IActionResult NhapCanHo()
        {
            return View();
        }

        public IActionResult ThemCanHo(CanHo ch)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(BaoTriCanHoChungCu_HK1_20_21.Models.StoreContext)) as StoreContext;
            context.ThemCanHo(ch);
            return View("NhapCanHo");
        }
    }
}
