using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class BusinessService : IBusinessService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public BusinessService(IUnitOfWork unitOfWork, IMapper mapper) {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<List<BusinessDTO>> GetNeighbourhoodBusinessesAsync(int neighbourhoodId)
    {
        return await _mapper.ProjectTo<BusinessDTO>(_unitOfWork.Businesses.FindByCondition(t => t.NeighbourhoodId == neighbourhoodId)).ToListAsync();
        
    }

    public async Task<BusinessDTO> CreateBusinessAsync(BusinessDTO business)
    {
        var businessEntity = _mapper.Map<Business>(business);
        await _unitOfWork.Businesses.Create(businessEntity);
        _unitOfWork.Save();
        return _mapper.Map<BusinessDTO>(businessEntity);
    }

    public async Task<BusinessDTO> GetBusinessById(int id)
    {
        var business = await _unitOfWork.Businesses.FindByCondition(t => t.Id == id).FirstOrDefaultAsync();

        if (business == null)
        {
            return null; 
        }

        var businessDto = _mapper.Map<BusinessDTO>(business);

        return businessDto;
    }
}