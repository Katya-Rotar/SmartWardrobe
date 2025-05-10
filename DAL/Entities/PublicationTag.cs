namespace DAL.Entities;

public class PublicationTag
{
    public int Id { get; set; }
    
    public int PublicationID { get; private set; }

    public int TagID { get; private set; }
    
    public Publication? Publication { get; set; }
    public Tag? Tag { get; set; }
}