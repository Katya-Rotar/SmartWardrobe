using DAL.Context.Configuration;

namespace DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;


public class WardrobeDbContext : DbContext
{
    public WardrobeDbContext(DbContextOptions<WardrobeDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<TemperatureSuitability> TemperatureSuitabilities { get; set; }
    public DbSet<Type> Types { get; set; }
    public DbSet<TypeCategory> TypeCategories { get; set; }
    public DbSet<ClothingItem> ClothingItems { get; set; }
    public DbSet<Season> Seasons { get; set; }
    public DbSet<ClothingItemSeason> ClothingItemSeasons { get; set; }
    public DbSet<Style> Styles { get; set; }
    public DbSet<ClothingItemStyle> ClothingItemStyles { get; set; }
    public DbSet<Outfit> Outfits { get; set; }
    public DbSet<OutfitItem> OutfitItems { get; set; }
    public DbSet<OutfitStyle> OutfitStyles { get; set; }
    public DbSet<OutfitSeason> OutfitSeasons { get; set; }
    public DbSet<OutfitGroup> OutfitGroups { get; set; }
    public DbSet<OutfitGroupItem> OutfitGroupItems { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<OutfitTag> OutfitTags { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Publication> Publications { get; set; }
    public DbSet<PublicationTag> PublicationTags { get; set; }
    public DbSet<PostLike> PostLikes { get; set; }
    public DbSet<SavedPost> SavedPosts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<CommentLike> CommentLikes { get; set; }
    public DbSet<Follower> Followers { get; set; }
    public DbSet<Notification> Notifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ProfileConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new TemperatureSuitabilityConfiguration());
        modelBuilder.ApplyConfiguration(new TypeConfiguration());
        modelBuilder.ApplyConfiguration(new TypeCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ClothingItemConfiguration());
        modelBuilder.ApplyConfiguration(new SeasonConfiguration());
        modelBuilder.ApplyConfiguration(new ClothingItemSeasonConfiguration());
        modelBuilder.ApplyConfiguration(new StyleConfiguration());
        modelBuilder.ApplyConfiguration(new ClothingItemStyleConfiguration());
        modelBuilder.ApplyConfiguration(new OutfitConfiguration());
        modelBuilder.ApplyConfiguration(new OutfitItemConfiguration());
        modelBuilder.ApplyConfiguration(new OutfitStyleConfiguration());
        modelBuilder.ApplyConfiguration(new OutfitSeasonConfiguration());
        modelBuilder.ApplyConfiguration(new OutfitGroupConfiguration());
        modelBuilder.ApplyConfiguration(new OutfitGroupItemConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
        modelBuilder.ApplyConfiguration(new OutfitTagConfiguration());
        modelBuilder.ApplyConfiguration(new EventConfiguration());
        modelBuilder.ApplyConfiguration(new PublicationConfiguration());
        modelBuilder.ApplyConfiguration(new PublicationTagConfiguration());
        modelBuilder.ApplyConfiguration(new PostLikeConfiguration());
        modelBuilder.ApplyConfiguration(new SavedPostConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfiguration(new CommentLikeConfiguration());
        modelBuilder.ApplyConfiguration(new FollowerConfiguration());
        modelBuilder.ApplyConfiguration(new NotificationConfiguration());
    }
}
