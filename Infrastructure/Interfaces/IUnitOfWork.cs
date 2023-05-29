namespace Infrastructure.Interfaces;

public interface IUnitOfWork
{
    INeighbourhoodRepository Neighbourhoods{ get; }
    IPostRepository Posts { get; }
    IBusinessRepository Businesses { get; }
    
    IUserNeighbourhoodRepositoy UserNeighbourhoods { get; }
    void Save();
}