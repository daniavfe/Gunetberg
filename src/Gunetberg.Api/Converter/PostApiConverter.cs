using Gunetberg.Api.Dto.Common;
using Gunetberg.Api.Dto.Post;
using Gunetberg.Api.Dto.Tag;
using Gunetberg.Domain.Common;
using Gunetberg.Domain.Post;
using Gunetberg.Domain.Tag;

namespace Gunetberg.Api.Converter
{
    public class PostApiConverter
    {
        public CreatePostRequest ToCreatePostRequest(CreatePostRequestDto createPostRequestDto, Guid userId)
        {
            return new CreatePostRequest
            {
                Title = createPostRequestDto.Title,
                Language = createPostRequestDto.Language,
                ImageUrl = createPostRequestDto.ImageUrl,
                Content = createPostRequestDto.Content,
                CreatedBy = userId
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
                CreatedBy = post.CreatedBy
            };
        }

        public IEnumerable<SummaryPostDto> ToSummaryPostDto(IEnumerable<SummaryPost> summaryPosts)
        {
            return summaryPosts.Select(x => ToSummaryPostDto(x));
        }

        public SimpleTagDto ToSimpleTagDto(SimpleTag simpleTag)
        {
            return new SimpleTagDto
            {
                Id = simpleTag.Id,
                Name = simpleTag.Name
            };
        }

        public SummaryPostDto ToSummaryPostDto(SummaryPost summaryPost)
        {
            return new SummaryPostDto
            {
                Id = summaryPost.Id,
                Title = summaryPost.Title,
                Summary = summaryPost.Summary,
                ImageUrl = summaryPost.ImageUrl,
                Language = summaryPost.Language,
                Tags = summaryPost.Tags.Select(x => ToSimpleTagDto(x))
            };
        }

        public PostFilterSortField ToPostFilterSortField(string sortFieldDto)
        {
            if (Enum.TryParse<PostFilterSortField>(sortFieldDto, out var result))
            {
                return result;
            }

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