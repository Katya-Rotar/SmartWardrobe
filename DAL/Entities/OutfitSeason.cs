namespace DAL.Entities;

public class OutfitSeason
{
    public int Id { get; set; }
    
    public int OutfitID { get; private set; }

    public int SeasonID { get; private set; }
    
    public Outfit? Outfit { get; set; }
    public Season? Season { get; set; }
}