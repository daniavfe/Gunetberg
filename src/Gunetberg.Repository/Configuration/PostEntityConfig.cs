using Gunetberg.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gunetberg.Repository.Configuration
{
    public class PostEntityConfig : IEntityTypeConfiguration<PostEntity>
    {
        public void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            builder.ToTable("posts");
            
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasDefaultValue(Guid.NewGuid());

            builder.Property(x => x.Title)
                .HasMaxLength(150)
                .IsRequired(true);

            builder.Property(x => x.Language)
                .HasMaxLength(10)
                .IsRequired(true);

            builder.Property(x => x.Summary)
                .HasMaxLength(150)
                .IsRequired(true);

            builder.Property(x => x.Content)
                .HasMaxLength(4000)
                .IsRequired(true);

            builder.Property(x => x.ImageUrl)
                .HasMaxLength(200)
                .IsRequired(false);


            builder.Property(x => x.CreatedBy)
                .IsRequired(true);

            builder.Property(x=>x.CreatedAt)
                .IsRequired(true);

            builder.HasIndex(x=>x.Title).IsUnique();

            builder.HasOne(x => x.Author).WithMany(x => x.Posts).HasForeignKey(x=>x.CreatedBy);

        }
    }
}
