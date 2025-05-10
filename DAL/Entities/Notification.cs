namespace DAL.Entities;

public class Notification
{
    public int Id { get; set; }
    
    public int UserID { get; private set; }

    public bool IsRead { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public int? EventID { get; private set; }
    
    public User? User { get; private set; }
    public Event? Event { get; set; }
}