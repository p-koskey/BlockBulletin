using Infrastructure.Interfaces;
using Infrastructure.Repositories;

namespace Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;
    private INeighbourhoodRepository _neighbourhoods;
    private IPostRepository _posts;
    private IBusinessRepository _businesses;
    private IUserNeighbourhoodRepositoy _userNeighbourhoods;

    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public INeighbourhoodRepository Neighbourhoods
    {
        get
        {
            if (_neighbourhoods == null)
            {
                _neighbourhoods = new NeighbourhoodRepository(_dbContext);
            }

            return _neighbourhoods;
        }
    }

    public IPostRepository Posts
    {
        get
        {
            if (_posts == null)
            {
                _posts = new PostRepository(_dbContext);
            }

            return _posts;
        }
        
    }
    
    public IBusinessRepository Businesses
    {
        get
        {
            if (_businesses == null)
            {
                _businesses = new BusinessRepository(_dbContext);
            }

            return _businesses;
        }
        
    }
    
    public IUserNeighbourhoodRepositoy UserNeighbourhoods
    {
        get
        {
            if (_userNeighbourhoods == null)
            {
                _userNeighbourhoods = new UserNeighbourhoodRepository(_dbContext);
            }

            return _userNeighbourhoods;
        }
        
    }
    public void Save()
    {
        _dbContext.SaveChanges();
    }
}