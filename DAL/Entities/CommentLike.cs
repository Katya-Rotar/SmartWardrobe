namespace DAL.Entities;

public class CommentLike
{
    public int Id { get; set; }
    
    public int ProfileID { get; private set; }

    public int CommentID { get; private set; }
    
    public Profile? Profile { get; private set; }
    public Comment? Comment { get; private set; }
}