using System.Security.Claims;
using Application.DTOs;
using Application.Interfaces;
using BlockBulletin.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlockBulletin.Controllers;

public class NeighbourhoodController : Controller
{
    private readonly INeighbourhoodService _neighbourhoodService;
    private readonly ClaimsPrincipal _user;
    private readonly int _userId;
    private readonly IBusinessService _businessService;
    private readonly IPostService _postService;

    public NeighbourhoodController(INeighbourhoodService neighbourhoodService, IHttpContextAccessor httpContextAccessor,
        IBusinessService businessService, IPostService postService)
    {
        _neighbourhoodService = neighbourhoodService;
        Int32.TryParse(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value, out _userId);
        _businessService = businessService;
        _postService = postService;
    }

    // GET
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(NeighbourhoodViewModel neighbourhoodViewModel)
    {
        if (ModelState.IsValid)
        {
            NeighbourhoodDTO data = new NeighbourhoodDTO()
            {
                Name = neighbourhoodViewModel.Name,
                Location = neighbourhoodViewModel.Location,
                Hospital = neighbourhoodViewModel.Hospital,
                Police = neighbourhoodViewModel.Police
            };
            var result = await _neighbourhoodService.CreateNeighbourhoodAsync(data, _userId);

            if (result != null)
            {
                await _neighbourhoodService.JoinNeighbourhoodAsync(_userId, result.Id);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid Data");

        }

        return RedirectToAction("Index", "Home");
    }

    public  async Task<IActionResult> ViewNeighbourhood(int id)
    {
        var neighbourhood = await _neighbourhoodService.GetNeighbourhoodById(id);

        if (neighbourhood == null)
        {
            return NotFound();
        }
        var businesses = await _businessService.GetNeighbourhoodBusinessesAsync(neighbourhood.Id);
        var posts = await _postService.GetNeighbourhoodPostsAsync(neighbourhood.Id);

        var neighbourhoodDTO = new NeighbourhoodDTO
        {
            Id = neighbourhood.Id,
            Name = neighbourhood.Name,
            Location = neighbourhood.Location,
            Hospital = neighbourhood.Hospital,
            Police = neighbourhood.Police,
            Businesses = businesses,
            Posts = posts
        };

        return View(neighbourhoodDTO);
        
    }
    
    public  async Task<IActionResult> JoinNeighbourhood(int id)
    {
        var join = await _neighbourhoodService.JoinNeighbourhoodAsync(_userId, id);
        
        if(join)  return RedirectToAction("Index", "Home");

        return NotFound();
    }
    
    public  async Task<IActionResult> LeaveNeighbourhood(int id)
    {
        var leave = await _neighbourhoodService.LeaveNeighbourhoodAsync(_userId, id);
        
        if(leave)  return RedirectToAction("Index", "Home");

        return NotFound();
    }
    
    
}