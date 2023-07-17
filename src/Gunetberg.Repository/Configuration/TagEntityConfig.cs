using Gunetberg.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gunetberg.Repository.Configuration
{
    public class TagEntityConfig : IEntityTypeConfiguration<TagEntity>
    {
        public void Configure(EntityTypeBuilder<TagEntity> builder)
        {
            builder.ToTable("tags");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasDefaultValue(Guid.NewGuid());

            builder.Property(x => x.Name)
                .HasMaxLength(30)
                .IsRequired(true);

            builder.Property(x => x.CreatedAt)
                .HasMaxLength(30)
                .IsRequired(true);
        }
    }
}
