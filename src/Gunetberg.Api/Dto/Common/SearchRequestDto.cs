namespace Gunetberg.Api.Dto.Common
{
    public class SearchRequestDto<T>
    {
        public int? Page { get; set; }
        public int? ItemsPerPage { get; set; }
        public string? SortField { get; set; }
        public bool? SortByDescending { get; set; }
        public T? Filter { get; set; }
    }
}
