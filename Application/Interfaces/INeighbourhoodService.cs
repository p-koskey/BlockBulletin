using Application.DTOs;

namespace Application.Interfaces;

public interface INeighbourhoodService
{
    public Task<List<NeighbourhoodDTO>> GetAllNeighbourhoodsAsync();
    public Task<NeighbourhoodDTO> CreateNeighbourhoodAsync(NeighbourhoodDTO neighbourhood, int userId);
    public Task<NeighbourhoodDTO> GetNeighbourhoodById(int id);
    
    public Task<NeighbourhoodDTO> GetNeighbourhoodByUserIdAsync(int id);

    public Task<bool> JoinNeighbourhoodAsync(int userId, int neighbourhoodId);
    
    public Task<bool> LeaveNeighbourhoodAsync(int userId, int neighbourhoodId);
}