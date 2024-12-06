using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game.Mod.Stormworks.Toolbox.Application.Database.Entities;
public class ComponentToImage : IEntityTypeConfiguration<ComponentToImage>
{
    public required Guid ComponentId { get; init; }
    public required Guid ImageId { get; init; }
    public required DateTime CreatedDateTimeUtc { get; init; }

    public void Configure(EntityTypeBuilder<ComponentToImage> builder)
    {
        builder
            .ToTable("ComponentsToImage")
            .HasKey(cti => new
            {
                cti.ComponentId,
                cti.ImageId,
            });
    }
}
