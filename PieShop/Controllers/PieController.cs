using Microsoft.AspNetCore.Mvc;
using PieShop.Models;

namespace PieShop.Controllers
{
    public class PieController : Controller
    {
        public IActionResult List()
        {
            ViewBag.CurrentCategory = "All pies";

            var pies = StaticPieData.GetAll();
            return View(pies);
        }

        public IActionResult Details(int id)
        {
            var pie = StaticPieData.GetById(id);

            if (pie is null)
            {
                return NotFound();
            }

            return View(pie);
        }

    }
}
