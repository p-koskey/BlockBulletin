namespace Domain.Entities;

public class Neighbourhood : Entity
{
    public string Name { get; set; }

    public string Location { get; set; }

    public int Hospital { get; set; }
    
    public int Police { get; set; }
}