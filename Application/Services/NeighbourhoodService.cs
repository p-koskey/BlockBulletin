using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class NeighbourhoodService : INeighbourhoodService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public NeighbourhoodService(IUnitOfWork unitOfWork, IMapper mapper) {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<List<NeighbourhoodDTO>> GetAllNeighbourhoodsAsync()
    {
        return await _mapper.ProjectTo<NeighbourhoodDTO>(_unitOfWork.Neighbourhoods.FindAll()).ToListAsync();
    }

    public async Task<NeighbourhoodDTO> CreateNeighbourhoodAsync(NeighbourhoodDTO neighbourhood, int userId)
    {
        var neighbourhoodEntity = _mapper.Map<Neighbourhood>(neighbourhood);
        await _unitOfWork.Neighbourhoods.Create(neighbourhoodEntity);
        _unitOfWork.Save();
        return _mapper.Map<NeighbourhoodDTO>(neighbourhoodEntity);
    }

    public async Task<NeighbourhoodDTO> GetNeighbourhoodById(int id)
    {
        var neighbourhood = await _unitOfWork.Neighbourhoods.FindByCondition(t => t.Id == id).FirstOrDefaultAsync();

        if (neighbourhood == null)
        {
            return null; 
        }

        var neighbourhoodDto = _mapper.Map<NeighbourhoodDTO>(neighbourhood);

        return neighbourhoodDto;
    }
    
    public async Task<NeighbourhoodDTO> GetNeighbourhoodByUserIdAsync(int userId)
    {
        var userNeighbourhood = await _unitOfWork.UserNeighbourhoods.FindByCondition(x => x.UserId == userId).FirstOrDefaultAsync();
        if (userNeighbourhood == null)
        {
            return null;
        }

        var neighbourhood =   _unitOfWork.Neighbourhoods.FindById(userNeighbourhood?.NeighbourhoodId);
        return _mapper.Map<NeighbourhoodDTO>(neighbourhood);
    }
    
    public async Task<bool> JoinNeighbourhoodAsync(int userId, int neighbourhoodId)
    {
        var neighbourhood =  _unitOfWork.Neighbourhoods.FindById(neighbourhoodId);
        if (neighbourhood == null)
        {
            return false; 
        }

        var userNeighbourhood = new UserNeighbourhood
        {
            UserId = userId,
            NeighbourhoodId = neighbourhoodId
        };

        await _unitOfWork.UserNeighbourhoods.Create(userNeighbourhood);
         _unitOfWork.Save();

        return true;
    }
    
    public async Task<bool> LeaveNeighbourhoodAsync(int userId, int neighbourhoodId)
    {
        var userNeighbourhood = await _unitOfWork.UserNeighbourhoods.FindByCondition(x => x.UserId == userId && x.NeighbourhoodId == neighbourhoodId).FirstOrDefaultAsync();
        if (userNeighbourhood == null)
        {
            return false;
        }

        _unitOfWork.UserNeighbourhoods.Delete(userNeighbourhood);
        _unitOfWork.Save();

        return true;
    }

    
}