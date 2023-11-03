using Gunetberg.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gunetberg.Repository.Configuration
{
    public class UserEntityConfig : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("users");

            builder.HasIndex(x => x.Id);

            builder.Property(x => x.Id)
                .HasDefaultValueSql("newsequentialid()");

            builder.Property(x => x.Email)
                .HasMaxLength(150)
                .IsRequired(true);

            builder.Property(x => x.Password)
                .HasMaxLength(200)
                .IsRequired(true);

            builder.Property(x=>x.Alias)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(x=>x.Description)
                .HasMaxLength(300)
                .IsRequired(false);

            builder.Property(x => x.PhotoUrl)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(x=>x.CreatedAt)
                .IsRequired(true);

            builder.Property(x => x.Role)
                .IsRequired(true);
        }
    }
}
