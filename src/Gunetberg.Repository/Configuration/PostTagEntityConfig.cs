using Gunetberg.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gunetberg.Repository.Configuration
{
    public class PostTagEntityConfig : IEntityTypeConfiguration<PostTagEntity>
    {
        public void Configure(EntityTypeBuilder<PostTagEntity> builder)
        {
            builder.ToTable("post_tags");

            builder.HasKey(x => new { x.PostId, x.TagId });

            builder.HasOne(x => x.Post).WithMany(x => x.PostTags);
            builder.HasOne(x => x.Tag).WithMany(x => x.PostTags);
        }
    }
}
