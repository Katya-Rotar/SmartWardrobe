namespace DAL.Entities;

public class Comment
{
    public int Id { get; set; }
    
    public int ProfileID { get; private set; }

    public int PublicationID { get; private set; }

    public string Content { get; private set; }

    public DateTime CreatedAt { get; private set; }
    
    public Profile? Profile { get; set; }
    public Publication? Publication { get; set; }
    
    public IEnumerable<CommentLike>? CommentLikes { get; set; } = new List<CommentLike>();
}