﻿namespace Gunetberg.Domain.User
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Alias { get; set; }
        public string? PhotoUrl { get; set; }
        public string? Description { get; set; }
    }
}
