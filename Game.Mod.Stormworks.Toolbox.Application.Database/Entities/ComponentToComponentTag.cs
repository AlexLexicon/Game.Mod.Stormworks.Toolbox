using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game.Mod.Stormworks.Toolbox.Application.Database.Entities;
public class ComponentToComponentTag : IEntityTypeConfiguration<ComponentToComponentTag>
{
    public required Guid ComponentId { get; init; }
    public required Guid ComponentTagId { get; init; }
    public required DateTime CreatedDateTimeUtc { get; init; }

    public required DateTime ModifiedDateTimeUtc { get; set; }

    public void Configure(EntityTypeBuilder<ComponentToComponentTag> builder)
    {
        builder
            .ToTable("ComponentsToComponentTags")
            .HasKey(ctct => new
            {
                ctct.ComponentId,
                ctct.ComponentTagId,
            });
    }
}
