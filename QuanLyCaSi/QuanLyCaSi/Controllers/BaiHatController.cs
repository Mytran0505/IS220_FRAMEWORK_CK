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
    }
}
