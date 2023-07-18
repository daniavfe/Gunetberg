﻿using Gunetberg.Domain.Tag;
using Gunetberg.Domain.User;

namespace Gunetberg.Domain.Post
{
    public class CompletePost
    {
        public Guid Id { get; set; }

        public string Language { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Content { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public IEnumerable<SimpleTag> Tags { get; set; }

        public Author Author { get; set; }

    }
}
