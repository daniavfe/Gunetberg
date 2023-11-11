namespace Gunetberg.Api.Dto.Common
{
    public class PaginationResultDto<T>
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
