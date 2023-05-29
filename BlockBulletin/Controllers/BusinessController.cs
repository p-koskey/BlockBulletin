using System.Security.Claims;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlockBulletin.Controllers;

public class BusinessController : Controller
{
    private readonly IBusinessService _businessService;
    private readonly ClaimsPrincipal _user;
    private readonly int _userId;
    
    public BusinessController(IBusinessService businessService, IHttpContextAccessor httpContextAccessor)
    {
        _businessService = businessService;
        Int32.TryParse(httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier).Value, out _userId);

    }
    [HttpPost]
    public async Task<IActionResult> Create(BusinessDTO businessDto)
    {
        if (ModelState.IsValid)
        {
            var business = new BusinessDTO()
            {
                Title = businessDto.Title,
                Description = businessDto.Description,
                NeighbourhoodId = businessDto.NeighbourhoodId,
                UserId = _userId
            };
            var result = await _businessService.CreateBusinessAsync(business);

            if (result != null)
            {
                return RedirectToAction("ViewNeighbourhood", "Neighbourhood", new {id = business.NeighbourhoodId});
            }

            ModelState.AddModelError(string.Empty, "Invalid Data");

        }

        return RedirectToAction("Index", "Home");
    }
}