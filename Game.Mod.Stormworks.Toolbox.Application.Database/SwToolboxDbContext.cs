using Game.Mod.Stormworks.Toolbox.Application.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Game.Mod.Stormworks.Toolbox.Application.Database;
public class SwToolboxDbContext : DbContext
{
    public SwToolboxDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Block> Blocks { get; set; }
    public DbSet<BlockToGameVersion> BlocksToGameVersions { get; set; }
    public DbSet<GameVersion> GameVersions { get; set; }
    public DbSet<BlockTag> BlockTags { get; set; }
    public DbSet<BlockTagToGameVersion> BlockTagsToGameVersions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyScanMarker).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
