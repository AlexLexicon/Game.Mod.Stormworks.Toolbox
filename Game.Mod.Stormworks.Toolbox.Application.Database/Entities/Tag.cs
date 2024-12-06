using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game.Mod.Stormworks.Toolbox.Application.Database.Entities;
public class Tag : IEntityTypeConfiguration<Tag>
{
    public required Guid Id { get; init; }
    public required DateTime CreatedDateTimeUtc { get; init; }

    public required string Text { get; set; }
    public required DateTime ModifiedDateTimeUtc { get; set; }

    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder
            .ToTable("Tags")
            .HasKey(t => t.Id);
    }
}
