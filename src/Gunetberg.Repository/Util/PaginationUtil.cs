using Gunetberg.Repository.Types;

namespace Gunetberg.Repository.Util
{
    public class PaginationUtil
    {

        public static Pagination GetPagination(int numberOfEntries, int? requestedPage, int? requestedItemsPerPage)
        {
            var selectedItemsPerPage = (requestedItemsPerPage != null && requestedItemsPerPage >= 10 && requestedItemsPerPage <= 25) ? requestedItemsPerPage.Value : 10;
            var availablePages = Math.Max((int)Math.Ceiling(numberOfEntries / (decimal)selectedItemsPerPage), 1);
            var selectedPage = (requestedPage != null && requestedPage <= availablePages && requestedPage > 0) ? requestedPage.Value : availablePages;

            return new Pagination
            {
                Page = selectedPage,
                Pages = availablePages,
                ItemsPerPage = selectedItemsPerPage
            };
        }

    }
}
