using PieShop.Models;
using PieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PieShop.Controllers;

public class PieController : Controller
{
    private readonly IPieRepository _pieRepository;

    public PieController(IPieRepository pieRepository)
    {
        _pieRepository = pieRepository;
    }


    //[HttpGet("")]
    public async Task<IActionResult> List(string? category)
    {
        ViewBag.Title = "Pie Overview";

        string currentCategory = "All pies";
        List<Pie> pies;

        if (string.IsNullOrWhiteSpace(category))
        {
            pies = await _pieRepository.GetAllAsync();
        }
        else
        {
            currentCategory = category.Trim();
            pies = await _pieRepository.GetByCategoryAsync(currentCategory);
        }

        var viewModel = new PieListViewModel
        {
            Pies = pies,
            CurrentCategory = currentCategory
        };

        return View(viewModel);
    }

    //[HttpGet("{id:int:min(1)}")]

    public async Task<IActionResult> Details(int id)
    {
        var pie = await _pieRepository.GetByIdAsync(id);

        return pie is null ? NotFound() : View(pie);
    }
}