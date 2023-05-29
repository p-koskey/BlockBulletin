using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class BusinessDTO : EntityDTO
{
    [Required]
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public int NeighbourhoodId { get; set; }
    
    [Required]
    public int UserId { get; set; }
}