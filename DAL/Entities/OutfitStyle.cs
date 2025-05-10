namespace DAL.Entities;

public class OutfitStyle
{
    public int Id { get; set; }
    
    public int OutfitID { get; private set; }

    public int StyleID { get; private set; }
    
    public Outfit? Outfit { get; set; }
    public Style? Style { get; set; }
}