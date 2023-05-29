using Application.Interfaces;
using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlockBulletin.Controllers;

public class HomeController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly INeighbourhoodService _neighbourhoodService;

    public HomeController(UserManager<User> userManager, INeighbourhoodService neighbourhoodService)
    {
        _userManager = userManager;
        _neighbourhoodService = neighbourhoodService;
    }
    // GET
    [Authorize]
    public async Task<IActionResult> Index()
    {
        var currentUser = await _userManager.GetUserAsync(User);
        var res = await _neighbourhoodService.GetAllNeighbourhoodsAsync();

        if (currentUser == null) return View(res);
        
        var userId = currentUser.Id;
        var result = await _neighbourhoodService.GetNeighbourhoodByUserIdAsync(userId);

        if (result != null)
        {
            return RedirectToAction("ViewNeighbourhood", "Neighbourhood", new { id = result.Id });

        }

        return View(res);
    }
    
    public IActionResult Privacy()
    {
        return View();
    }
}