using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunetberg.Domain.Post
{
    public class PostSummary
    {
        public Guid Id { get; set; }

        public string Language { get; set; }

        public string Title { get; set; }

        public string SummaryContent { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
