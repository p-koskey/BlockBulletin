using System.Security.Claims;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlockBulletin.Controllers;

public class PostController : Controller
{
    private readonly IPostService _postService;
    private readonly ClaimsPrincipal _user;
    private readonly int _userId;
    
    public PostController(IPostService postService, IHttpContextAccessor httpContextAccessor)
    {
        _postService = postService;
        Int32.TryParse(httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier).Value, out _userId);

    }
    [HttpPost]
    public async Task<IActionResult> Create(PostDTO postDto)
    {
        if (ModelState.IsValid)
        {
            var post = new PostDTO()
            {
                Title = postDto.Title,
                Description = postDto.Description,
                NeighbourhoodId = postDto.NeighbourhoodId,
                UserId = _userId
            };
            var result = await _postService.CreatePostAsync(post);

            if (result != null)
            {
                return RedirectToAction("ViewNeighbourhood", "Neighbourhood", new {id = postDto.NeighbourhoodId});
            }

            ModelState.AddModelError(string.Empty, "Invalid Data");

        }

        return RedirectToAction("Index", "Home");
    }
}