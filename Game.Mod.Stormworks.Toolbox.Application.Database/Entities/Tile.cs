using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game.Mod.Stormworks.Toolbox.Application.Database.Entities;
public class Tile : IEntityTypeConfiguration<Tile>
{
    public required Guid Id { get; init; }
    public required DateTime CreatedDateTimeUtc { get; init; }

    public required string Name { get; set; }
    public required DateTime ModifiedDateTimeUtc { get; set; }

    public void Configure(EntityTypeBuilder<Tile> builder)
    {
        builder
            .ToTable("Tiles")
            .HasKey(t => t.Id);
    }
}
