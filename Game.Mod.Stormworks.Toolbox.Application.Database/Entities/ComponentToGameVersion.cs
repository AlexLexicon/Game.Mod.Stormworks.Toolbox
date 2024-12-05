using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game.Mod.Stormworks.Toolbox.Application.Database.Entities;
public class ComponentToGameVersion : IEntityTypeConfiguration<ComponentToGameVersion>
{
    public required Guid ComponentId { get; init; }
    public required Guid GameVersionId { get; init; }
    public required DateTime CreatedDateTimeUtc { get; init; }

    public required DateTime ModifiedDateTimeUtc { get; set; }

    public void Configure(EntityTypeBuilder<ComponentToGameVersion> builder)
    {
        builder
            .ToTable("ComponentsToGameVersions")
            .HasKey(ctgv => new
            {
                ctgv.ComponentId,
                ctgv.GameVersionId,
            });
    }
}
