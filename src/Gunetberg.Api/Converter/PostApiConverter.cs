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
            return summaryPosts.Select(ToSummaryPostDto);
        }

        public SummaryPostDto ToSummaryPostDto(SummaryPost summaryPost)
        {
            return new SummaryPostDto();
        }

        public SearchRequest<PostFilterRequest> ToSearchPostRequest(SearchPostRequestDto searchPostRequestDto)
        {
            return new SearchRequest<PostFilterRequest>();
        }

        public SearchPostResultDto ToSearchPostResultDto(SearchResult<SummaryPost> searchResult)
        {
            return new SearchPostResultDto();
        }
    }
}
