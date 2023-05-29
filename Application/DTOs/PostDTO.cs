namespace Application.DTOs;

public class PostDTO : EntityDTO
{
    public string Title { get; set; }

    public string Description { get; set; }

    public int NeighbourhoodId { get; set; }
    
    public int UserId { get; set; }
    
}