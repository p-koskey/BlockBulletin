using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class UserNeighbourhoodRepository : Repository<UserNeighbourhood>, IUserNeighbourhoodRepositoy
{
    public UserNeighbourhoodRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}