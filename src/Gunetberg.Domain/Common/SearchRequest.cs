namespace Gunetberg.Domain.Common
{
    public class SearchRequest<T>
    {
        public int? Page { get; set; }
        public int? ItemsPerPage { get; set; }
        public string? SortField { get; set; }
        public bool SortByDescending { get; set; }
        public T? FilterRequest { get; set; }
    }
}
