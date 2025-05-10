namespace DAL.Entities;

public class PostLike
{
    public int Id { get; set; }
    
    public int ProfileID { get; private set; }

    public int PublicationID { get; private set; }
    
    public Profile? Profile { get; set; }
    public Publication? Publication { get; set; }
}