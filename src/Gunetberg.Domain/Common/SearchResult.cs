namespace Gunetberg.Domain.Common
{
    public class SearchResult<T>
    {
        public int Page { get; set; }
        public int Pages { get; set; }
        public int ItemsPerPage { get; set; }
        public string? SortingField { get; set; }
        public bool SortByDescending { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}
