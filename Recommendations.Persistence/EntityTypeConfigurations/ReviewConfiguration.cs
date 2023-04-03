using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recommendations.Domain;

namespace Recommendations.Persistence.EntityTypeConfigurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Discussion>
{
    public void Configure(EntityTypeBuilder<Discussion> builder)
    {
        builder.HasKey(review => review.Id);
        builder.HasIndex(review => review.Id).IsUnique();

        builder.Property(review => review.Title)
            .HasMaxLength(100);

        builder.Property(review => review.Description)
            .HasMaxLength(5000);
    }
}