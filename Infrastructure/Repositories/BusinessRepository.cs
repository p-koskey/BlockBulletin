using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class BusinessRepository: Repository<Business>, IBusinessRepository
{
    public BusinessRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}