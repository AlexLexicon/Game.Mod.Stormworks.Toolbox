using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game.Mod.Stormworks.Toolbox.Application.Database.Entities;
public class BlockToGameVersion : IEntityTypeConfiguration<BlockToGameVersion>
{
    public required Guid BlockId { get; init; }
    public required Guid GameVersionId { get; init; }
    public required DateTime CreatedDateTimeUtc { get; init; }

    public required DateTime ModifiedDateTimeUtc { get; set; }

    public void Configure(EntityTypeBuilder<BlockToGameVersion> builder)
    {
        builder
            .ToTable("BlocksToGameVersions")
            .HasKey(btgv => new
            {
                btgv.BlockId,
                btgv.GameVersionId,
            });
    }
}
