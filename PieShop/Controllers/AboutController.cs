using Microsoft.AspNetCore.Mvc;

namespace PieShop.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
