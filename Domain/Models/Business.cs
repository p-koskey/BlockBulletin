namespace Domain.Entities;

public class Business : Entity
{
    public string Title { get; set; }

    public string Description { get; set; }

    public int NeighbourhoodId { get; set; }
    
    public int UserId { get; set; }
}