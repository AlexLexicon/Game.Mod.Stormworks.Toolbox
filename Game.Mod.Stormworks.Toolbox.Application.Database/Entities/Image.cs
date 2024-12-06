using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game.Mod.Stormworks.Toolbox.Application.Database.Entities;
public class Image : IEntityTypeConfiguration<Image>
{
    public required Guid Id { get; init; }
    public required DateTime CreatedDateTimeUtc { get; init; }

    public required string Base64Data { get; set; }
    public required DateTime ModifiedDateTimeUtc { get; set; }

    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder
            .ToTable("Images")
            .HasKey(i => i.Id);
    }
}
