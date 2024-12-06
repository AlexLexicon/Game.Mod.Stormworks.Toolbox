using Game.Mod.Stormworks.Toolbox.Application.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Game.Mod.Stormworks.Toolbox.Application.Database;
public class SwToolboxDbContext : DbContext
{
    public SwToolboxDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Component> Components { get; set; }
    public DbSet<ComponentToImage> ComponentsToImage { get; set; }
    public DbSet<ComponentToTag> ComponentsToTags { get; set; }
    public DbSet<GameVersion> GameVersions { get; set; }
    public DbSet<GameVersionToComponent> GameVersionsToComponents { get; set; }
    public DbSet<GameVersionToTile> GameVersionsToTiles { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Tile> Tiles { get; set; }
    public DbSet<TileToImage> TilesToImage { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyScanMarker).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
