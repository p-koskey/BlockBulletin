using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class NeighbourhoodDTO : EntityDTO
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Location { get; set; }
    [Required]
    public int Hospital { get; set; }
    [Required]
    public int Police { get; set; }
    
    public List<BusinessDTO> Businesses { get; set; }
    
    public List<PostDTO> Posts { get; set; }
    
}