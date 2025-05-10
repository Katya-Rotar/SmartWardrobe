namespace DAL.Entities;

public class Season
{
    public int Id { get; set; }
    
    public string SeasonName { get; private set; }
    
    public IEnumerable<OutfitSeason>? OutfitSeasons { get; set; } = new List<OutfitSeason>();
    public IEnumerable<ClothingItemSeason> ClothingItemSeasons { get; set; } = new List<ClothingItemSeason>();
}