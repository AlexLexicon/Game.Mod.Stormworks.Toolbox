using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game.Mod.Stormworks.Toolbox.Application.Database.Entities;
public class Block : IEntityTypeConfiguration<Block>
{
    public required Guid Id { get; init; }
    public required DateTime CreatedDateTimeUtc { get; init; }

    public required string Name { get; set; }

    public required int Order { get; set; }
    public required string Category { get; set; }

    public required int Price { get; set; }
    public required int Mass { get; set; }
    public required int Motor { get; set; }
    public required int MotorSpeed { get; set; }
    public required int Force { get; set; }
    public required int Power { get; set; }
    public required int Range { get; set; }

    public required DateTime ModifiedDateTimeUtc { get; set; }

    public void Configure(EntityTypeBuilder<Block> builder)
    {
        builder
            .ToTable("Blocks")
            .HasKey(b => b.Id);
    }
}
