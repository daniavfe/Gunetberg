using Gunetberg.Api.Dto.Post;
using Gunetberg.Domain.Post;

namespace Gunetberg.Api.Converter
{
    public class PostApiConverter
    {
        public CreatePostRequest ToCreatePostRequest(CreatePostRequestDto createPostApiRequest)
        {
            return new CreatePostRequest();
        }

        public PostDto ToPostDto(Post post)
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

        public SearchPostRequest ToSearchPostRequest(SearchPostRequestDto searchPostRequestDto)
        {
            return new SearchPostRequest();
        }

        public SearchPostResultDto ToSearchPostResultDto(SearchPostResult searchPostResult)
        {
            return new SearchPostResultDto();
        }
    }
}
