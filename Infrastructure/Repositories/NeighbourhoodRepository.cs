using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class NeighbourhoodRepository : Repository<Neighbourhood>, INeighbourhoodRepository
{
    public NeighbourhoodRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}