using AdRooms.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<AdListing> AdListings { get; set; }
    public DbSet<AdImage> AdImages { get; set; }
    public DbSet<FavouriteAd> FavouriteAds { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<ModerateUser> ModerateUsers { get; set; }

    public DbSet<Interact> Interactions { get; set; }

    private readonly IConfiguration _configuration;

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("users"); 
        modelBuilder.Entity<AdListing>().ToTable("ad_listings").HasKey(ad => ad.Id);
        modelBuilder.Entity<AdListing>()
            .Property(ad => ad.UserId)
            .HasColumnName("user_id");
        modelBuilder.Entity<Category>().ToTable("category");
        modelBuilder.Entity<AdImage>().ToTable("ad_images");
        modelBuilder.Entity<FavouriteAd>().ToTable("favourite_ad");
        modelBuilder.Entity<FavouriteAd>().HasNoKey();
        modelBuilder.Entity<ModerateUser>().ToTable("moderate_user");
        modelBuilder.Entity<ModerateUser>().HasNoKey();
        modelBuilder.Entity<Interact>().ToTable("interact");

        base.OnModelCreating(modelBuilder);
    }

}
