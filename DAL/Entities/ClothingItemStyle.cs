namespace DAL.Entities;

public class ClothingItemStyle
{
    public int Id { get; set; }
    
    public int ClothingItemID { get; private set; }

    public int StyleID { get; private set; }
    
    public ClothingItem? ClothingItem { get; set; }
    public Style? Style { get; set; }
}