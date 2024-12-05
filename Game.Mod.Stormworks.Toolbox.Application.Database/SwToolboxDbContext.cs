using Game.Mod.Stormworks.Toolbox.Application.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Game.Mod.Stormworks.Toolbox.Application.Database;
public class SwToolboxDbContext : DbContext
{
    public SwToolboxDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Component> Blocks { get; set; }
    public DbSet<ComponentToGameVersion> ComponentsToGameVersions { get; set; }
    public DbSet<GameVersion> GameVersions { get; set; }
    public DbSet<ComponentTag> BlockTags { get; set; }
    public DbSet<ComponentToComponentTag> ComponentsToComponentTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyScanMarker).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
