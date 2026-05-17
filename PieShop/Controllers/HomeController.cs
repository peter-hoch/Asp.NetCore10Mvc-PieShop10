using PieShop.Models;
using PieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace PieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public async Task<ViewResult> Index()
        {
            var piesOfTheWeek = (await _pieRepository.GetAllAsync()).Where(p => p.IsPieOfTheWeek);
            var homeViewModel = new HomeViewModel(piesOfTheWeek);
            return View(homeViewModel);
        }
    }
}
