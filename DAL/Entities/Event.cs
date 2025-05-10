namespace DAL.Entities;

public class Event
{
    public int Id { get; set; }
    
    public int UserID { get; private set; }

    public string Name { get; private set; }

    public DateTime Date { get; private set; }

    public string Location { get; private set; }

    public string DressCode { get; private set; }

    public int? OutfitID { get; private set; }
    
    public User? User { get; private set; }
    public Outfit? Outfit { get; private set; }
    
    public IEnumerable<Notification> Notifications { get; set; } = new List<Notification>();
}