using Gunetberg.Repository.Configuration;
using Gunetberg.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gunetberg.Repository.Context
{
    public class RepositoryContext : DbContext
    {
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<PostTagEntity> PostTags { get; set; }
        public DbSet<TagEntity> Tags { get; set; }

        public RepositoryContext(DbContextOptions options): base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new PostEntityConfig().Configure(modelBuilder.Entity<PostEntity>());
            new UserEntityConfig().Configure(modelBuilder.Entity<UserEntity>());
            new TagEntityConfig().Configure(modelBuilder.Entity<TagEntity>());
            new PostTagEntityConfig().Configure(modelBuilder.Entity<PostTagEntity>());
        }
    }
}
