using System.ComponentModel.DataAnnotations;

namespace BlockBulletin.ViewModels;

public class NeighbourhoodViewModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Location { get; set; }
    [Required]
    public int Hospital { get; set; }
    [Required]
    public int Police { get; set; }
}