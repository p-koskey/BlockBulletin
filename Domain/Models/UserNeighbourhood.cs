
namespace Domain.Entities;
public class UserNeighbourhood : Entity
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int NeighbourhoodId { get; set; }
    
}