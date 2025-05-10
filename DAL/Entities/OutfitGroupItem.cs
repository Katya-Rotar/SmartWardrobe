namespace DAL.Entities;

public class OutfitGroupItem 
{
    public int Id { get; set; }
    
    public int OutfitGroupID { get; private set; }

    public int OutfitID { get; private set; } 
    
    public OutfitGroup? OutfitGroup { get; set; }
    public Outfit? Outfit { get; set; }
}