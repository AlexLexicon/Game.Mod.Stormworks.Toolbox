using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game.Mod.Stormworks.Toolbox.Application.Database.Entities;
public class GameVersionToTile : IEntityTypeConfiguration<GameVersionToTile>
{
    public required Guid Id { get; init; }
    public required Guid TileId { get; init; }
    public required Guid GameVersionId { get; init; }
    public required DateTime CreatedDateTimeUtc { get; init; }

    public void Configure(EntityTypeBuilder<GameVersionToTile> builder)
    {
        builder
            .ToTable("GameVersionsToTiles")
            .HasKey(ctgv => ctgv.Id);

        builder.HasIndex(ctgv => ctgv.TileId);
        builder.HasIndex(ctgv => ctgv.GameVersionId);
    }
}
