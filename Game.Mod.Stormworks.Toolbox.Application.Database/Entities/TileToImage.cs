using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game.Mod.Stormworks.Toolbox.Application.Database.Entities;
public class TileToImage : IEntityTypeConfiguration<TileToImage>
{
    public required Guid TileId { get; init; }
    public required Guid ImageId { get; init; }
    public required DateTime CreatedDateTimeUtc { get; init; }

    public void Configure(EntityTypeBuilder<TileToImage> builder)
    {
        builder
            .ToTable("TilesToImage")
            .HasKey(cti => new
            {
                cti.TileId,
                cti.ImageId,
            });
    }
}
