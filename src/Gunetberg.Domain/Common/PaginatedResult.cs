namespace Gunetberg.Domain.Common
{
    public class PaginatedResult<T>
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
