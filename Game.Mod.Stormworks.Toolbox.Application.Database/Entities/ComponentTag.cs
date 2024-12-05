using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game.Mod.Stormworks.Toolbox.Application.Database.Entities;
public class ComponentTag : IEntityTypeConfiguration<ComponentTag>
{
    public required Guid Id { get; init; }
    public required DateTime CreatedDateTimeUtc { get; init; }

    public required string Value { get; init; }

    public required DateTime ModifiedDateTimeUtc { get; set; }

    public void Configure(EntityTypeBuilder<ComponentTag> builder)
    {
        builder
            .ToTable("ComponentTags")
            .HasKey(ct => ct.Id);
    }
}
