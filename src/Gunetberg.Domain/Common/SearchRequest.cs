namespace Gunetberg.Domain.Common
{
    public class SearchRequest<F, S>
    {
        public int? Page { get; set; }
        public int? ItemsPerPage { get; set; }
        public S SortField { get; set; }
        public bool? SortByDescending { get; set; }
        public F? FilterRequest { get; set; }
    }
}
