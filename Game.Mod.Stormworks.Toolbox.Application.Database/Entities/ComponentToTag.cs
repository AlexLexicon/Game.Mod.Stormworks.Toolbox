using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game.Mod.Stormworks.Toolbox.Application.Database.Entities;
public class ComponentToTag : IEntityTypeConfiguration<ComponentToTag>
{
    public required Guid Id { get; init; }
    public required Guid ComponentId { get; init; }
    public required Guid TagId { get; init; }
    public required DateTime CreatedDateTimeUtc { get; init; }

    public void Configure(EntityTypeBuilder<ComponentToTag> builder)
    {
        builder
            .ToTable("ComponentsToTags")
            .HasKey(ctt => ctt.Id);

        builder.HasIndex(ctgv => ctgv.ComponentId);
        builder.HasIndex(ctgv => ctgv.TagId);
    }
}
