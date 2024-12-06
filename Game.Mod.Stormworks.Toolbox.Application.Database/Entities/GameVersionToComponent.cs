using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game.Mod.Stormworks.Toolbox.Application.Database.Entities;
public class GameVersionToComponent : IEntityTypeConfiguration<GameVersionToComponent>
{
    public required Guid Id { get; init; }
    public required Guid ComponentId { get; init; }
    public required Guid GameVersionId { get; init; }
    public required DateTime CreatedDateTimeUtc { get; init; }

    public void Configure(EntityTypeBuilder<GameVersionToComponent> builder)
    {
        builder
            .ToTable("GameVersionsToComponents")
            .HasKey(ctgv => ctgv.Id);

        builder.HasIndex(ctgv => ctgv.ComponentId);
        builder.HasIndex(ctgv => ctgv.GameVersionId);
    }
}
