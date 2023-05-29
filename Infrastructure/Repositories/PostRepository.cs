using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class PostRepository : Repository<Post>, IPostRepository
{
    public PostRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}