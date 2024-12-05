using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game.Mod.Stormworks.Toolbox.Application.Database.Entities;
public class BlockTagToGameVersion : IEntityTypeConfiguration<BlockTagToGameVersion>
{
    public required Guid BlockTagId { get; init; }
    public required Guid GameVersionId { get; init; }
    public required DateTime CreatedDateTimeUtc { get; init; }

    public required DateTime ModifiedDateTimeUtc { get; set; }

    public void Configure(EntityTypeBuilder<BlockTagToGameVersion> builder)
    {
        builder
            .ToTable("BlockTagsToGameVersions")
            .HasKey(bttgv => new
            {
                bttgv.BlockTagId,
                bttgv.GameVersionId,
            });
    }
}
