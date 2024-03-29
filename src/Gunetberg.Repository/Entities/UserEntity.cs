﻿namespace Gunetberg.Repository.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Alias { get; set; }
        public RoleEntity Role { get; set; }
        public string? PhotoUrl { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<PostEntity> Posts { get; set; }
        public IEnumerable<CommentEntity> Comments { get; set; }
    }
}
