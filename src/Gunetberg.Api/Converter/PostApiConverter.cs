using Gunetberg.Api.Dto.Common;
using Gunetberg.Api.Dto.Post;
using Gunetberg.Domain.Common;
using Gunetberg.Domain.Post;

namespace Gunetberg.Api.Converter
{
    public class PostApiConverter
    {
        public CreatePostRequest ToCreatePostRequest(CreatePostRequestDto createPostRequestDto)
        {
            return new CreatePostRequest
            {
                Title = createPostRequestDto.Title,
                Language = createPostRequestDto.Language,
                ImageUrl = createPostRequestDto.ImageUrl,
                Content = createPostRequestDto.Content,
            };
        }

        public CompletePostDto ToPostDto(CompletePost post)
        {
            return new CompletePostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                ImageUrl = post.ImageUrl,
                Language = post.Language,
                CreatedAt = post.CreatedAt,
            };
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
                Summary = summaryPost.Summary,
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
