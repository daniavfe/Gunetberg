﻿using Gunetberg.Domain.Common;
using Gunetberg.Domain.Post;

namespace Gunetberg.Port.Input
{
    public interface IPostService
    {
        Task<SearchResult<SummaryPost>> SearchPosts(SearchRequest<PostFilterRequest, PostFilterSortField> searchRequest);

        Task<Guid> CreatePost(CreatePostRequest createPostRequest);

        Task UpdatePost(UpdatePostRequest updatePostRequest);

        Task<UpdatePost> GetUpdatePost(Guid id);

        Task<CompletePost> GetPost(string title);

        Task DeletePost(Guid id);

        Task<SearchResult<AdminPost>> SearchAdminPosts(SearchRequest<PostFilterRequest, PostFilterSortField> searchRequest);
    }
}
