namespace DAL.Entities;

public class Publication
{
    public int Id { get; set; }
    
    public int ProfileID { get; private set; }

    public int OutfitID { get; private set; }

    public string ImageURL { get; private set; }

    public bool CommentingOptions { get; private set; }
    
    public Profile? Profile { get; set; }
    public Outfit? Outfit { get; set; }
    
    public IEnumerable<SavedPost>? SavedPosts { get; set; } = new List<SavedPost>();
    public IEnumerable<PublicationTag>? PublicationTags { get; set; } = new List<PublicationTag>();
    public IEnumerable<PostLike>? PostLikes { get; set; } = new List<PostLike>();
    public IEnumerable<Comment>? Comments { get; set; } = new List<Comment>();
}