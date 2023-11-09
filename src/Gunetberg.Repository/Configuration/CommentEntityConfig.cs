using Gunetberg.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gunetberg.Repository.Configuration
{
    public class CommentEntityConfig : IEntityTypeConfiguration<CommentEntity>
    {
        public void Configure(EntityTypeBuilder<CommentEntity> builder)
        {
            builder.ToTable("comments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasDefaultValueSql("newsequentialid()");

            builder.Property(x => x.Content)
                .HasMaxLength(250)
                .IsRequired(true);

            builder.Property(x => x.PostId)
                .IsRequired(true);

            builder.Property(x => x.CreatedAt)
                .IsRequired(true);

            builder.Property(x => x.CreatedBy)
                .IsRequired(true);

            builder.Property(x => x.ParentId)
                .IsRequired(false);

            builder.HasOne(x => x.User).WithMany(x => x.Comments).HasForeignKey(x => x.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Post).WithMany(x => x.Comments).HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Parent).WithMany(x => x.SubComments).HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
