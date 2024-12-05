using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game.Mod.Stormworks.Toolbox.Application.Database.Entities;
public class GameVersion : IEntityTypeConfiguration<GameVersion>
{
    public required Guid Id { get; init; }
    public required DateTime CreatedDateTimeUtc { get; init; }

    public required string Name { get; set; }
    public required DateTime ReleaseDate { get; set; }

    public required DateTime ModifiedDateTimeUtc { get; set; }

    public void Configure(EntityTypeBuilder<GameVersion> builder)
    {
        builder
            .ToTable("GameVersions")
            .HasKey(gv => gv.Id);
    }
}
