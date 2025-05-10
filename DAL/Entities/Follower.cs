namespace DAL.Entities;

public class Follower
{
    public int Id { get; set; }
    
    public int FollowerID { get; private set; }

    public int FollowingID { get; private set; }

    public DateTime CreatedAt { get; private set; }
    
    public Profile? FollowerProfile { get; set; }
    public Profile? FollowingProfile { get; set; }
}