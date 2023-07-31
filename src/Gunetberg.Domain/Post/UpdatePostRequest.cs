﻿
namespace Gunetberg.Domain.Post
{
    public class UpdatePostRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public Guid CreatedBy { get; set; }
        public string? ImageUrl { get; set; }
        public string Content { get; set; }
        public IEnumerable<Guid> Tags { get; set; }
    }
}
