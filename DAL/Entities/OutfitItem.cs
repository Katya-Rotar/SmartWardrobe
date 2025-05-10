namespace DAL.Entities;

public class OutfitItem 
{
    public int Id { get; set; }
    
    public int OutfitID { get; private set; }

    public int ClothingItemID { get; private set; }
    
    public Outfit? Outfit { get; set; }
    public ClothingItem? ClothingItem { get; set; }
}