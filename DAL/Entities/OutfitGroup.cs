namespace DAL.Entities;

public class OutfitGroup
{
    public int Id { get; set; }
    
    public int UserID { get; private set; }

    public string GroupName { get; private set; }

    public string? Description { get; private set; }

    public DateTime CreatedAt { get; private set; } 
    
    public User? User { get; set; }
    
    public IEnumerable<OutfitGroupItem>? OutfitGroups { get; set; } = new List<OutfitGroupItem>();
}