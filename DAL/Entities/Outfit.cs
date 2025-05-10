namespace DAL.Entities;

public class Outfit
{
    public int Id { get; set; }
    
    public int UserID { get; private set; }

    public int TemperatureSuitabilityID { get; private set; }
    
    public User? User { get; set; }
    public TemperatureSuitability? TemperatureSuitability { get; set; }
    
    public IEnumerable<Publication>? Publications { get; set; } = new List<Publication>();
    public IEnumerable<OutfitTag>? Tags { get; set; } = new List<OutfitTag>();
    public IEnumerable<OutfitStyle>? Styles { get; set; } = new List<OutfitStyle>();
    public IEnumerable<OutfitSeason>? Seasons { get; set; } = new List<OutfitSeason>();
    public IEnumerable<OutfitItem>? Items { get; set; } = new List<OutfitItem>();
    public IEnumerable<OutfitGroupItem>? GroupItems { get; set; } = new List<OutfitGroupItem>();
    public IEnumerable<Event>? Events { get; set; } = new List<Event>();
}