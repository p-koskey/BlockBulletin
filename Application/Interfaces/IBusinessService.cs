using Application.DTOs;

namespace Application.Interfaces;

public interface IBusinessService
{
    public Task<List<BusinessDTO>> GetNeighbourhoodBusinessesAsync(int neighbourhoodId);
    public Task<BusinessDTO> CreateBusinessAsync(BusinessDTO business);
    public Task<BusinessDTO> GetBusinessById(int id);
}