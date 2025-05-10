namespace DAL.Entities;

public class OutfitTag
{
    public int Id { get; set; }
    
    public int OutfitID { get; private set; }

    public int TagID { get; private set; }
    
    public Outfit? Outfit { get; set; }
    public Tag? Tag { get; set; }
}