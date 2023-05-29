using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class PostService : IPostService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public PostService(IUnitOfWork unitOfWork, IMapper mapper) {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<List<PostDTO>> GetNeighbourhoodPostsAsync(int neighbourhoodId)
    {
        return await _mapper.ProjectTo<PostDTO>(_unitOfWork.Posts.FindByCondition(t => t.NeighbourhoodId == neighbourhoodId)).ToListAsync();
        
    }

    public async Task<PostDTO> CreatePostAsync(PostDTO post)
    {
        var postEntity = _mapper.Map<Post>(post);
        await _unitOfWork.Posts.Create(postEntity);
        _unitOfWork.Save();
        return _mapper.Map<PostDTO>(postEntity);
    }

    public async Task<PostDTO> GetPostById(int id)
    {
        var post = await _unitOfWork.Posts.FindByCondition(t => t.Id == id).FirstOrDefaultAsync();

        if (post == null)
        {
            return null; 
        }

        var postDto = _mapper.Map<PostDTO>(post);

        return postDto;
    }
}