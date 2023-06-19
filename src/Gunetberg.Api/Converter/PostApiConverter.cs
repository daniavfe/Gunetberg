using Gunetberg.Api.Dto.Common;
using Gunetberg.Api.Dto.Post;
using Gunetberg.Domain.Common;
using Gunetberg.Domain.Post;

namespace Gunetberg.Api.Converter
{
    public class PostApiConverter
    {
        public CreatePostRequest ToCreatePostRequest(CreatePostRequestDto createPostApiRequest)
        {
            return new CreatePostRequest();
        }

        public PostDto ToPostDto(CompletePost post)
        {
            return new PostDto();
        }

        public IEnumerable<SummaryPostDto> ToSummaryPostDto(IEnumerable<SummaryPost> summaryPosts)
        {
            return summaryPosts.Select(x=>ToSummaryPostDto(x));
        }

        public SummaryPostDto ToSummaryPostDto(SummaryPost summaryPost)
        {
            return new SummaryPostDto
            {
                Id = summaryPost.Id,
                Title = summaryPost.Title,
                Content = summaryPost.Content,
                ImageUrl = summaryPost.ImageUrl            
            };
        }

        public PostFilterSortField ToPostFilterSortField(string sortFieldDto)
        {
            return PostFilterSortField.CreatedAt;
        }

        public SearchRequest<PostFilterRequest, PostFilterSortField> ToSearchPostRequest(SearchRequestDto<PostFilterRequestDto> searchPostRequestDto)
        {
            return new SearchRequest<PostFilterRequest, PostFilterSortField>
            {
                Page = searchPostRequestDto?.Page,
                ItemsPerPage = searchPostRequestDto?.ItemsPerPage,
                SortField = ToPostFilterSortField(searchPostRequestDto?.SortField),
                SortByDescending = searchPostRequestDto.SortByDescending,
                FilterRequest = new PostFilterRequest
                {
                    FilterByTitle = searchPostRequestDto?.Filter?.FilterByTitle
                }
                
            };
        }


        public SearchResultDto<SummaryPostDto> ToSearchPostResultDto(SearchResult<SummaryPost> searchResult)
        {
            return new SearchResultDto<SummaryPostDto>
            {
                Page = searchResult.Page,
                Pages = searchResult.Pages,
                ItemsPerPage = searchResult.ItemsPerPage,
                SortByDescending = searchResult.SortByDescending,
                SortingField = searchResult.SortingField,
                Items = ToSummaryPostDto(searchResult.Items)
            };
        }
    }
}
