using Application.DTOs;

namespace Application.Interfaces;

public interface IPostService
{
    public Task<List<PostDTO>> GetNeighbourhoodPostsAsync(int neighbourhoodId);
    public Task<PostDTO> CreatePostAsync(PostDTO post);
    public Task<PostDTO> GetPostById(int id);
}